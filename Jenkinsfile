pipeline {
    agent any

    stages {

        stage('Checkout Code') {
            steps {
                echo "Checking out code from Git..."
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo "Restoring NuGet packages..."
                bat 'dotnet restore ApiA/ApiA/ApiA.csproj'
                bat 'dotnet restore ApiB/ApiB/ApiB.csproj'
            }
        }

        stage('Build') {
            steps {
                echo "Building ApiA..."
                bat 'dotnet build ApiA/ApiA/ApiA.csproj -c Release'

                echo "Building ApiB..."
                bat 'dotnet build ApiB/ApiB/ApiB.csproj -c Release'
            }
        }

        stage('Publish Output') {
            steps {
                echo "Publishing ApiA..."
                bat 'dotnet publish ApiA/ApiA/ApiA.csproj -c Release -o publish/ApiA'

                echo "Publishing ApiB..."
                bat 'dotnet publish ApiB/ApiB/ApiB.csproj -c Release -o publish/ApiB'
            }
        }

        stage('Create ZIP Artifacts') {
            steps {
                echo "Zipping published output..."

                powershell """
                    Compress-Archive -Path publish/ApiA/* -DestinationPath publish/ApiA.zip -Force
                    Compress-Archive -Path publish/ApiB/* -DestinationPath publish/ApiB.zip -Force
                """
            }
        }

    }

    post {
        success {
            echo "Build completed successfully!"
            archiveArtifacts artifacts: 'publish/*.zip', allowEmptyArchive: false
        }
        failure {
            echo "Build failed!"
        }
    }
}
