# GitHub Pages Deployment Guide

This GitHub Action workflow automatically deploys the Blazor WebAssembly app to GitHub Pages whenever you push to the `full-cook-daisy` branch.

## 🚀 Setup Instructions

### Step 1: Enable GitHub Pages

1. Go to your repository on GitHub: `https://github.com/jamesmontemagno/SimplePetApp`
2. Click on **Settings** tab
3. Scroll down to **Pages** in the left sidebar
4. Under **Build and deployment**:
   - Source: Select **GitHub Actions**
   - (Not "Deploy from a branch")

### Step 2: Commit and Push the Workflow

The workflow file has been created at `.github/workflows/deploy-to-github-pages.yml`

```bash
git add .github/workflows/deploy-to-github-pages.yml
git commit -m "Add GitHub Pages deployment workflow"
git push origin full-cook-daisy
```

### Step 3: Monitor the Deployment

1. Go to the **Actions** tab in your GitHub repository
2. You should see the "Deploy Blazor WASM to GitHub Pages" workflow running
3. Wait for the workflow to complete (usually takes 2-3 minutes)

### Step 4: Access Your Deployed App

Once deployed, your app will be available at:
```
https://jamesmontemagno.github.io/SimplePetApp/
```

## 🔄 Automatic Deployments

After the initial setup, the workflow will automatically:
- Trigger on every push to the `main` branch
- Build the Blazor WebAssembly app
- Publish the output
- Deploy to GitHub Pages

You can also manually trigger the deployment:
1. Go to **Actions** tab
2. Select "Deploy Blazor WASM to GitHub Pages"
3. Click **Run workflow**

## 🛠️ What the Workflow Does

1. **Checkout Code**: Gets the latest code from the repository
2. **Setup .NET 9**: Installs .NET 9 SDK
3. **Restore Dependencies**: Restores NuGet packages
4. **Build**: Compiles the project in Release mode
5. **Publish**: Creates optimized production build
6. **Update Base Href**: Changes the base path to `/SimplePetApp/` for proper routing
7. **Add .nojekyll**: Prevents GitHub from processing the site with Jekyll
8. **Create 404.html**: Enables client-side routing fallback
9. **Upload Artifact**: Prepares files for deployment
10. **Deploy**: Publishes to GitHub Pages

## 📝 Configuration Notes

### Base Href
The workflow automatically updates the base href in `index.html` from `/` to `/SimplePetApp/` to match the GitHub Pages subdirectory structure.

### Client-Side Routing
The workflow copies `index.html` to `404.html` to enable Blazor's client-side routing to work correctly on GitHub Pages.

### .nojekyll File
This file tells GitHub Pages not to use Jekyll processing, which is important for Blazor apps.

## 🐛 Troubleshooting

### Workflow Fails
- Check the **Actions** tab for detailed error messages
- Ensure GitHub Pages is enabled with "GitHub Actions" as the source
- Verify the repository has the correct permissions

### App Not Loading
- Clear browser cache
- Check browser console for errors
- Verify the base href is correctly set to `/SimplePetApp/`

### 404 Errors on Refresh
- Ensure `404.html` was created during deployment
- This file enables client-side routing fallback

## 🔒 Permissions

The workflow requires the following permissions (already configured):
- `contents: read` - To read repository contents
- `pages: write` - To deploy to GitHub Pages
- `id-token: write` - For GitHub Actions authentication

## 📦 Production Considerations

For production deployments, consider:
- Setting up a custom domain
- Enabling HTTPS (automatically enabled with GitHub Pages)
- Implementing proper error tracking
- Adding analytics

## 🎉 Success!

Once deployed, your Blazor WebAssembly app will be live and accessible to anyone with the URL. The app will automatically redeploy whenever you push changes to the main branch.
