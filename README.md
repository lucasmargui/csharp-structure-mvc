
<H1 align="center">Project: C# MVC Structure</H1>
<p align="center">🚀 Project to create a mvc structure for future references</p>

<div align="center">
<h3>Index<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/d4e793d0-b51c-4185-9249-4be8b90545df" style="width:70%">
</div>

<div align="center">
<h3>List<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/5102bf6e-1ac2-4e8e-b699-0ff3409130e3" style="width:70%">
</div>
  
<div align="center">
<h3>Create<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/5b782f57-17dd-4b01-b463-eb0aa425bf5f" style="width:70%">
</div>
  
<div align="center">
<h3>Edit<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/8731c5a5-2ce1-4139-889a-dc86357f1cdb" style="width:70%">
</div>
  
<div align="center">
<h3>Delete<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/1af5623f-33cc-4762-8cb8-f545dc3d5386" style="width:70%">
</div>



## Template create

<details>
   <summary>Click to show content</summary>

<br>

Select the Asp.NET Core Web Application (MVC) template

<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/bba2eb37-f962-4108-8369-b1d7a74ae2a0" style="width:90%">
</div>

 
</details>

## Model create

- UserModel.cs
- User.cs


## Controller create


<details>
   <summary>Click to show content</summary>
  
Right click on the Controller and Add -> Controller
With the name UsuarioController and add the following structure

<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/11172748-0c78-46b5-9b17-c16a94ae3f00" style="width:90%">
</div>

</details>



## Views create

<details>
   <summary>Click to show content</summary>
  
Create views from controller methods. Right-click on the Index() method and select Add View;
And repeat the process to create a view for each CRUD method

* Index() of the UsuarioController controller
* Create() of the UsuarioController controller
* Details() of the UsuarioController controller
* Delete() from the UsuarioController controller
* Edit() of the UsuarioController controller


### Select controller methods


<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/f68e6cbe-a1e6-49a8-b463-fa9d95fc9d11" style="width:90%">
</div>

### Razor Display


<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/3ab19956-a78a-4dd6-9280-a3acbc96e2d1" style="width:90%">
</div>

### Settings



<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/99d49918-ab58-4794-8ec8-71e46a9fa12a" style="width:90%">
</div>

</details>




## Changing Links

<details>
   <summary>Click to show content</summary>
  
### Add creation link to Index


<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/50197316-51d8-44cf-aa19-0562caa69c33" style="width:90%">
</div>

### Changing the links for each item


<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/145c1fbd-e987-4292-8d91-ae99e47ab732" style="width:90%">
</div>


</details>


## Shared change


<details>
   <summary>Click to show content</summary>
  
Before running the project, we will change the _Layout.chstml file in the /Shared folder, including the line highlighted in blue below in the file:
```
<ul id="menu">
  <li>@Html.ActionLink("Home", "Index", "Home")</li>
  <li>@Html.ActionLink("About", "About", "Home")</li>
  <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
  <li>@Html.ActionLink("User", "Index", "User")</li>
</ul>
```

</details>



