# Makefile for iLM Machine Backend (EF Core + .NET API)

# Usage Examples:
# make run
# make migrate name=AddHadithTable
# make update-db
# make clean-db

# Run the .NET API
run:
	dotnet run

# Add a new EF Core migration
migrate:
	dotnet ef migrations add $(name)

# Apply EF Core migrations to update the database
update-db:
	dotnet ef database update

# Clean and rebuild the project
build:
	dotnet build

# Remove bin & obj folders (clean build)
clean:
	rm -rf bin obj

# Reset DB (drop & recreate schema from scratch)
reset-db:
	dotnet ef database drop --force --yes
	dotnet ef database update
