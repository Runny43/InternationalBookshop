<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookDetails.aspx.cs" Inherits="InternationalBookshop.View.bookDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet"
    id="theme_link"
    href="https://cdnjs.cloudflare.com/ajax/libs/bootswatch/5.3.1/lux/bootstrap.min.css" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
<title>Book Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
    <div class="container-fluid">
        <a runat="server" id="UserNameIfLogged" class="navbar-brand" href="#">TripAdvisor</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarColor01">
            <ul class="navbar-nav me-auto">
                <li class="nav-item">
                    <a class="nav-link active" href="main.aspx">Home
                    
            <span class="visually-hidden">(current)</span>
                    </a>
                    <a class="nav-link active" href="MyBooks.aspx">My trolley</a>
                </li>
                
            </ul>
            
                <input class="form-control me-sm-2" type="search" placeholder="Search"/>
                <button class="btn btn-secondary my-2 my-sm-0" type="submit">Search</button>
            
        </div>
    </div>
</nav>
             <div class="row" style="margin-top: 20px; display: flex; justify-content: center; align-items: center;">
     <asp:Repeater ID="repBook" runat="server">
         <HeaderTemplate></HeaderTemplate>
         <ItemTemplate>
            
             <div class="card mb-3" style="width: 18rem; margin-left: 12px; height: 35rem">
                 <h3 class="card-header"><%# Eval("title")%></h3>
                 <img src="<%# Eval("photoPath")%>" class="d-block w-100" alt="..." />
                 <div class="card-body">
                 </div>
             </div>
             <div class="form-group">

                 <div class="row">
                     <h4 class="btn btn-primary">Book for $<%# Eval("Price")%> /p</h4>
                 </div>
                 <div class="row">
                     <h6>(no additional taxes or booking fees)</h6>
                 </div>
                 <div class="row">
                     <button runat="server" id="btnSaveTrolley" class="btn btn-primary" onserverclick="btnSaveTrolley_ServerClick">Add to cart</button>
                 </div>
             </div>
         </ItemTemplate>
         <FooterTemplate></FooterTemplate>
     </asp:Repeater>
                 
 </div>
            </div>
    </form>
</body>
</html>
