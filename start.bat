cd Backend

set VRITUALENV_DIR=env
set REQUIREMENTS_FILE=requirements.txt
if not exist %VRITUALENV_DIR%\Scripts\activate.bat (
    echo Creating venv...
    virtualenv env
    call %VRITUALENV_DIR%\Scripts\activate.bat
    echo Intalling dependencies...
    pip install -r %REQUIREMENTS_FILE%
)
else (
    echo Venv already exists. Skipping creation...
    call %VRITUALENV_DIR%\Scripts\activate.bat
)

start "" /MIN cmd /C python main.py

cd ../deploy
3DHandTracking.exe