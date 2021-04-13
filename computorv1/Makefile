all : clean restore build
 
clean:
	@dotnet clean
	@echo "\033[32m[✓] dotnet clean !\033[0m"
	@rm -rf ./obj ./bin
	@echo "\033[32m[✓] removing /bin and /obj folders !\033[0m"
 
restore:
	@dotnet restore
	@echo "\033[32m[✓] dotnet restore !\033[0m"
 
build:
	@dotnet build
	@echo "\033[32m[✓] dotnet build !\033[0m"
	@echo "\033[36m[i] run the app by typing \"dotnet run --args\" !\033[0m"
