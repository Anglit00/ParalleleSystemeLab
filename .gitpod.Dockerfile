FROM gitpod/workspace-dotnet:6.0

# Install specific .NET SDK version
RUN sudo apt-get update \
    && sudo apt-get install -y dotnet-sdk-6.0=6.0.25-1 \
    && sudo apt-get clean && sudo rm -rf /var/lib/apt/lists/*
