# 🐾 MyPetVenues - Simple Pet App

Welcome to **MyPetVenues** - a modern Blazor WebAssembly application for discovering and managing pet-friendly venues! 🏪🐕

## 📋 About

MyPetVenues is a web application that helps pet owners find and explore pet-friendly locations. Built with cutting-edge .NET 9 and Blazor WebAssembly technology, it provides a fast, responsive, and engaging user experience.

## ✨ Features

🌟 **Modern Web Experience**
- 🚀 Blazor WebAssembly for lightning-fast performance
- 📱 Responsive design that works on all devices
- ⚡ Client-side rendering for smooth interactions

🐾 **Pet-Friendly Focus**
- 🗺️ Discover pet-friendly venues and locations
- 📍 Location-based services
- 🏪 Venue information and details

## 🛠️ Technology Stack

- **Framework**: 🌐 Blazor WebAssembly
- **Runtime**: ⚙️ .NET 9
- **Language**: 💎 C# 12
- **Styling**: 🎨 CSS with Bootstrap
- **Build Tool**: 🔨 .NET CLI

## 📋 Prerequisites

Before running this application, make sure you have:

- 💻 [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed
- 🌐 A modern web browser (Chrome, Firefox, Safari, Edge)
- 📝 A code editor like [Visual Studio Code](https://code.visualstudio.com/) (optional)

## 🚀 Getting Started

### 📦 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/jamesmontemagno/SimplePetApp.git
   cd SimplePetApp
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the application**
   ```bash
   dotnet build
   ```

### 🏃‍♂️ Running the Application

To start the development server:

```bash
dotnet run --project MyPetVenues
```

Or for watch mode (auto-reload on changes):

```bash
dotnet watch --project MyPetVenues
```

The application will be available at:
- 🌐 **HTTP**: `http://localhost:5000`
- 🔒 **HTTPS**: `https://localhost:5001`

## 🏗️ Development

### 📁 Project Structure

```
SimplePetApp/
├── 📄 SimplePetApp.sln          # Solution file
└── MyPetVenues/                 # Main Blazor WebAssembly project
    ├── 📱 App.razor             # Root app component
    ├── 🏠 Pages/                # Razor pages/components
    ├── 🎨 Layout/               # Layout components
    ├── 🌐 wwwroot/              # Static web assets
    ├── 📝 Program.cs            # Application entry point
    └── ⚙️ MyPetVenues.csproj    # Project file
```

### 🔧 Development Commands

- **Build**: `dotnet build` 🔨
- **Run**: `dotnet run --project MyPetVenues` 🏃‍♂️
- **Watch**: `dotnet watch --project MyPetVenues` 👀
- **Clean**: `dotnet clean` 🧹
- **Restore**: `dotnet restore` 📦

## 🚀 Deployment

### 📦 Building for Production

To create a production build:

```bash
dotnet publish MyPetVenues -c Release -o publish
```

The optimized files will be in the `publish/wwwroot` directory, ready for deployment to any static web host! 🌍

### ☁️ Deployment Options

- 🌐 **Azure Static Web Apps**
- 📦 **GitHub Pages**
- 🔥 **Firebase Hosting**  
- 🌊 **Netlify**
- 🚀 **Vercel**

## 🤝 Contributing

We welcome contributions! 🎉 Here's how you can help:

1. 🍴 Fork the repository
2. 🌿 Create a feature branch (`git checkout -b feature/amazing-feature`)
3. 💍 Commit your changes (`git commit -m 'Add amazing feature'`)
4. 📤 Push to the branch (`git push origin feature/amazing-feature`)
5. 🔄 Open a Pull Request

## 📄 License

This project is open source and available under the [MIT License](LICENSE). 📜

## 🙏 Acknowledgments

- 💙 Built with [Blazor WebAssembly](https://blazor.net/)
- ⚡ Powered by [.NET 9](https://dotnet.microsoft.com/)
- 🎨 Styled with modern CSS

---

Made with ❤️ for pet lovers everywhere! 🐕🐱🐾

**Happy coding!** 🎉✨