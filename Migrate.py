from argparse import ArgumentParser
import sys 
from os import listdir, walk, system, environ
from os.path import join

#  From https://stackoverflow.com/questions/1724693/find-a-file-in-python
def find_all(name, path):
    results = []
    for root, dirs, files in walk(path):
        if name in files:
            results.append(join(root, name))
    return results

ENV_USERNAME = "USERNAME_392"
ENV_PASSWORD = "PASSWORD_392"
ENV_SERVER = "SERVER_392"

environment_contains_user = ENV_USERNAME in environ 
environment_contains_password = ENV_PASSWORD in environ 
environment_contains_server = ENV_SERVER in environ

parser = ArgumentParser()
parser.add_argument("--task", required=True, choices=['up', 'down', 'rollback', 'list'], help="The migration task to perform; one of up|down|rollback|list")
parser.add_argument("--database", required=False, help="The name of the database to use.  Defaults to the value of the --user argument if not specified")
parser.add_argument("--server", required=False, help="The name of the server to connect to.  Defaults to (LocalDB) if not specified")

parser.add_argument(
    "--user", required=False, 
    help=f"The user name to connect to the server with; this can also be set in the environment variable {ENV_USERNAME}")

parser.add_argument(
    "--password", required=False, 
    help=f"The password to use to connect to the database; this can also be set in the environnment variable {ENV_PASSWORD}")

parser.add_argument("--version", required=False, type=int, help="The migration number to rollback to")
parser.add_argument("--verbose", action="store_true", help="Output diagnostic information about what migrate.py is doing")
arguments = parser.parse_args()

if not environment_contains_user and not arguments.user:
    sys.exit(f"You must either set the environment variable {ENV_USERNAME} or provide a value for the --user argument")

if not environment_contains_password and not arguments.password:
    sys.exit(f"You must either set the environment variable {ENV_PASSWORD} or provide a value for the --password argument")

if not environment_contains_server:
    if not arguments.server:
        arguments.server = "(LocalDB)\\MSSQLLocalDB"    
        print(f"Neither the environment variable {ENV_SERVER} nor the --server argument are set.  Using default of {arguments.server}")      
elif environment_contains_server and arguments.server:
    print(f"Both the environment variable {ENV_SERVER} and the --server arguments have values; using the --server argument of {arguments.server} ")
else:    
    arguments.server = environ[ENV_SERVER]      

if environment_contains_user: 
    if not arguments.user:
        arguments.user = environ[ENV_USERNAME]
    else:
        print(f"Both the environment variable {ENV_USERNAME} and the --user arguments have values; using the --user value of {arguments.user}")

if environment_contains_password: 
    if not arguments.password:
        arguments.password = environ[ENV_PASSWORD]
    else:
        print(f"Both the environment variable {ENV_PASSWORD} and the --password arguments have values; using the --password value of {arguments.password}")

if arguments.task == "rollback" and not arguments.version:    
    print("You must enter a value for --version if --task=rollback")
    print("The value of --version should be the migration number you want to rollback to")
    sys.exit(-1)

if not arguments.database:
    arguments.database = arguments.user 
    if arguments.verbose:
        print(f"No value specified for --database; default to value of --user which is {arguments.user}")

if arguments.task == "rollback":
    task = f"--task rollback:toversion --version {arguments.version}"
elif arguments.task != "list":
    task = f"--task migrate:{arguments.task}"    
else:
    task = "--task listmigrations"

projectDir = "."
packageDir = join(projectDir, "packages");

if arguments.verbose:
    print (f"Searching for FluentMigrator.Console in {packageDir}")

packages = [dir for dir in listdir(packageDir) if dir.startswith("FluentMigrator.Console")]
#packages = [dir for dir in listdir(packageDir) if dir.startswith("FluentMigrator.Tools")]
if len(packages) == 0:
    print(f"Can't find FluentMigrator.console in directory {packageDir}")
    sys.exit(-1)

FluentMigrator = packages[0]
if arguments.verbose:
    print(f"Found {FluentMigrator}")

startingDirectory = join(packageDir, FluentMigrator)
if arguments.verbose:
    print (f"Looking for Migrate.exe in {startingDirectory}")

executableCandidates = find_all("Migrate.exe", startingDirectory)

if len(executableCandidates)==0:
    print(f"Cannot find Migrate.exe in {startingDirectory}")
    sys.exit(-1)

if arguments.verbose:
    print(f"Found {len(executableCandidates)} candidates for Migrate.exe")

executable = [executable for executable in executableCandidates if "any" in executable.lower()][0]

if arguments.verbose:
    print(f"Found Migrate.exe in path: {executable}")

cmd = f"{executable} --conn \"server={arguments.server};Trusted_Connection=false;uid={arguments.user};Password={arguments.password};Initial Catalog={arguments.database}\""  
#cmd = f"{executable} --conn \"server={arguments.server};Trusted_Connection=true;Initial Catalog={arguments.database}\""  

cmd = f"{cmd} --provider sqlserver2008 --assembly {join('Migrations', 'bin', 'Debug', 'Migrations.dll')}"
cmd = f"{cmd} {task}"

if arguments.verbose:
    print(f"System command is\n{cmd}")

system(cmd)