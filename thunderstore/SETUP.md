# Thunderstore Package Files

This folder contains the files needed for publishing to Thunderstore.

## Required Files

### icon.png (YOU MUST ADD THIS)
- **Size**: 256x256 pixels (exactly)
- **Format**: PNG
- **This file is required** - the workflow will fail without it!

### manifest.json ✓
Contains mod metadata. Version is automatically updated by the workflow.

### README.md ✓
The description shown on your Thunderstore mod page.

## Setup Instructions

1. **Create an icon.png** (256x256 pixels) and place it in this folder

2. **Get your Thunderstore token**:
   - Go to https://thunderstore.io/settings/teams/
   - Create or select your team
   - Go to "Service Accounts" tab
   - Create a new service account and copy the token

3. **Add the token to GitHub secrets**:
   - Go to your GitHub repository
   - Settings → Secrets and variables → Actions
   - Click "New repository secret"
   - Name: `THUNDERSTORE_TOKEN`
   - Value: (paste your token)

4. **Update the workflow** (`.github/workflows/publish-thunderstore.yml`):
   - Change `namespace` to your Thunderstore team name
   - Update `website_url` in manifest.json to your repo URL
   - Adjust categories if needed

## Publishing

To publish a new version:
1. Update the version in `Plugin.cs` and `FalseSonRealLobbySize.csproj`
2. Commit your changes
3. Create and push a new tag: `git tag v1.0.1 && git push origin v1.0.1`
4. The workflow will automatically build and publish to Thunderstore!
