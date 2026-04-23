SOLUTION="OptionChainVisualizer.slnx"

echo "Start CI/CD Checks"

echo "---Start Package Restore---"
dotnet restore $SOLUTION
echo "---End Package Restore---"

echo "---Start Build---"
dotnet build $SOLUTION --configuration Release --no-restore
echo "---End Build---"

echo "---Start Format---"
dotnet format $SOLUTION --verify-no-changes --verbosity minimal
echo "---End Format---"

echo "---Start Test---"
dotnet test $SOLUTION --configuration Release --no-build
echo "---End Test---"

echo "---Start Vulnerability Check (Server)---"
dotnet list OptionVisualizer/OptionVisualizer.Server/OptionVisualizer.Server.csproj package --vulnerable
echo "---End Vulnerability Check (Server)---"

echo "---Start Vulnerability Check (Calculations)---"
dotnet list Option.Calculations/Option.Calculations.csproj package --vulnerable
echo "---End Vulnerability Check (Calculations)---"

echo "CI/CD checks complete."
read -p "Enter to Close"
