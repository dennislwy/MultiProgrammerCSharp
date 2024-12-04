# MultiProgrammer CLI Tool

This repository contains the MultiProgrammer CLI Tool, a command-line interface for interacting with ICDmini devices. The tool provides various commands to manage and operate on ICDmini devices connected to your PC.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Download & Install .NET 6

To download and install .NET 6, follow these steps:

1. Visit the [.NET 6 download page](https://dotnet.microsoft.com/download/dotnet/6.0).
2. Download the installer for your operating system.
3. Run the installer and follow the instructions to complete the installation.

## Build the CLI

To build the CLI tool, follow these steps:

1. Clone the repository:
    ```sh
    git clone https://github.com/dennislwy/MultiProgrammerCSharp.git
    cd MultiProgrammerCSharp
    ```

2. Restore the dependencies and build the project:
    ```sh
    dotnet build -c Release -o bin
    ```

3. Make sure copy all necessary C17MultiProgrammer files to 'bin' folder
    - MultiProgrammer.dll
    - MultiProgrammer.ini
    - etc..

## Usage Help
`MultiProgrammerCli.exe -h` will show the following usage help information

```
MultiProgrammer CLI Tool

Usage:
  MultiProgrammerCli [command] [options]

Options:
  --version       Show version information
  -?, -h, --help  Show help and usage information

Commands:
  InitializeTargetInfo   Initializes target MCU information and user program
  ReleaseTargetInfo      Model-specific information file release
  OpenIcdConnection      Connects an ICDmini to the corresponding specified ICD handle
  CloseIcdConnection     Disconnects an ICDmini from the corresponding specified ICD handle
  ResetTarget            Resets the target for the target system connected to the ICDmini corresponding to the specified ICD handle
  CheckTargetConnection  Checks the connection to the target system connected to the ICDmini corresponding to the specified ICD handle
  StartOperation         Start a programming operation
  GetStatus              Fetches the processing status for the ICDmini corresponding to the specified ICD handle
  GetString              Returns a text string in response to a return code
  GetConnectedIcd        Fetches information for the ICDmini connected to the PC
```

## Usage Example

Here are some examples of how to use the MultiProgrammer CLI Tool:

<!-- 1. **Initialize Target Info**:
    ```sh
    MultiProgrammerCli.exe InitializeTargetInfo --targetInfo <targetInfo> --userInfo <userInfo>
    ``` -->

2. **Release Target Info**:
    ```sh
   MultiProgrammerCli.exe ReleaseTargetInfo
    ```

3. **Open ICD Connection**:
    ```sh
    MultiProgrammerCli.exe OpenIcdConnection --icdHandle <icdHandle>
    ```

4. **Close ICD Connection**:
    ```sh
    MultiProgrammerCli.exe CloseIcdConnection --icdHandle <icdHandle>
    ```

5. **Reset Target**:
    ```sh
    MultiProgrammerCli.exe ResetTarget --icdHandle <icdHandle>
    ```

6. **Check Target Connection**:
    ```sh
    MultiProgrammerCli.exe CheckTargetConnection --icdHandle <icdHandle>
    ```

7. **Get Status**:
    ```sh
    MultiProgrammerCli.exe GetStatus --icdHandle <icdHandle>
    ```

8. **Get Connected ICDs**:
    ```sh
    MultiProgrammerCli.exe GetConnectedIcd --maxCount <maxCount>
    ```

For more detailed information on each command, refer to the documentation or use the `--help` option with any command.
