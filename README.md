# xamarin-mvvm-light
Sample project for using MvvmLight in a Xamarin.Forms project

Steps to produce this basic project shell.

1. Open Visual Studio 2017 and create a new project (**File->New->Project**)
2. Use the same name that you'll use for your final cross-platform Xamarin project, so C# *namespaces* are the same
3. Save the new project in a temporary location, not the normal folder you use for code projects
4. The type of the project should be the *MvvmLight (iPhone)* that is available from the list of project templates
5. If this project type is not available, you need to install the MvvmLight **extension**. [see here](http://www.mvvmlight.net/installing/)
6. Build the project in VS2017 to make sure there are no errors
7. Close the first VS solution, and create a new one, with a new project. Use the exact same name as the first project, but save this in your normal code folder
8. This time, choose the project type *Moble App (Xamarin.Forms)*

    a. use the **Shared Project** Code Sharing Strategy
    
9. This new project will not have the sample folders with a View Model and a View Model Locator. We'll copy them from the first project
10. Inside VS, with the second project/solution open, manually add new folders in the **shared** code project (not the project whose name ends in .OS, .Android, or .UWP).
11. Using Windows Explorer, copy the `ViewModel`, `Model`, and `Design` folders from the first project into the second

    a. These 3 folders should be stored in the same project folder that will have App.xaml and MainPage.xaml
    b. Step 10 should already have created the folders. Just add the C# files to them from the first project
    
12. Right-click on each folder (ViewModel, Model, and Design) in VS and choose **Add->Existing Items** to add these files to the shared project
13. Using the NuGet package manager, add the MvvmLight and CommonServiceLocator libraries to your solution, for **all** projects
14. In the code I moved in, I needed to change `using Microsoft.Practices.ServiceLocation;
` to `using CommonServiceLocator;` because the code wouldn't compile for me
15. In the App.xaml file, add a resource for your ViewModelLocator class:

```xml

<?xml version="1.0" encoding="utf-8" ?>
<Application xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:d1p1="http://schemas.openxmlformats.org/markup-compatibility/2006"
             d1p1:Ignorable="d"
             x:Class="XamarinMvvmLightTest.App">
    <Application.Resources>
        <ResourceDictionary>
            <vm:ViewModelLocator x:Key="Locator" d:IsDataSource="True" xmlns:vm="clr-namespace:XamarinMvvmLightTest.ViewModel" />
        </ResourceDictionary>
    </Application.Resources>
</Application>

```

16. In your MainPage.xaml (or whichever file is your XAML UI), use data binding to get data from your view model:

```xml

             xmlns:VM="clr-namespace:XamarinMvvmLightTest.ViewModel"
             BindingContext="{Binding Source={StaticResource Locator}, Path=Main}"

```

    a. In the above example, it requires you to have a property named `Main` in your view model locator class:
    
```cs

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

````
    b. Then in the XAML, code like this will bind a label to a viewmodel property named `WelcomeTitle`:
    
```cs

        <Label Text="{Binding WelcomeTitle, Mode=OneWay}"

```

Now, Build and Run!
