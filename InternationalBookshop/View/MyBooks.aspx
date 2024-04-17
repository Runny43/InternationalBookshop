<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyBooks.aspx.cs" Inherits="InternationalBookshop.View.MyBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet"
        id="theme_link"
        href="https://cdnjs.cloudflare.com/ajax/libs/bootswatch/5.3.1/lux/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    <title>My Cart</title>
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
                                <a class="nav-link active" href="main.aspx">Home</a>
                                <a class="nav-link active" href="MyBooks.aspx">My trolley</a>
                            </li>

                        </ul>

                    </div>
                </div>
            </nav>
            <div class="row" style="margin-top: 20px; display: flex; justify-content: center; align-items: center;">

                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">Cart</th>
                            <th scope="col">Book title</th>
                            <th scope="col">ISBN</th>
                            <th scope="col">Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repTrolley" runat="server">
                            <HeaderTemplate></HeaderTemplate>
                            <ItemTemplate>
                                <tr class="table-primary">
                                    <th scope="row">Primary</th>
                                    <td><%# Eval("title")%></td>
                                    <td><%# Eval("ISBN")%></td>
                                    <td><%# Eval("Price")%></td>
                                </tr>

                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

                <fieldset>
                    <legend>Legend</legend>
                    <div class="row">
                        <label for="txtCountry" class="col-sm-2 col-form-label">Country:</label>
                        <div class="col-sm-10">
                            <input type="text" readonly="" class="form-control-plaintext" id="txtCountry" />
                        </div>
                    </div>
                    <div>
                        <label for="txtProvince" class="form-label mt-4">Province:</label>
                        <input type="text" class="form-control" id="txtProvince" />
                    </div>
                    <div>
                        <label for="txtAddress" class="form-label mt-4">Address</label>
                        <input type="text" class="form-control" id="txtAddress" />
                    </div>
                    <div>
                        <label for="txtPostalCode" class="form-label mt-4">Postal code:</label>
                        <input type="number" class="form-control" id="txtPostalCode" />
                    </div>
                    <div>
                        <label for="txtCardNumber" class="form-label mt-4">Card Number</label>
                        <input type="number" class="form-control" id="txtCardNumber" />
                    </div>
                    <div>
                        <label for="txtSecurityCode" class="form-label mt-4">Security Code</label>
                        <input type="number" class="form-control" id="txtSecurityCode" />
                    </div>
                    <div class="card-body">
                        
                    <div class="form-group">
         <div class="row">
             <div class="col">
                 <label for="checkout" class="form-label mt-4">Check Out</label>
             </div>
             <div class="col">
                 <input runat="server" type="date" class="form-control" id="dtCheckOut" placeholder="date" autocomplete="off" />
             </div>
         </div>
     </div>
                        </div>
                </fieldset>
                <div>
                    <h2 class="navbar-brand">Precio total:</h2>
                    <h3 runat="server" id="PrecioTotal" class="navbar-brand">0</h3>
                    <div class="row">
                        <button runat="server" id="btnBuyBooks" class="btn btn-primary" onserverclick="btnBuyBooks_ServerClick">Buy books</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
