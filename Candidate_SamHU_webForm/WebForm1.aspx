<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Candidate_SamHU_webForm.WebForm1" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
</head>



<body>
    <div class="container">
        <div class="row">
            <div class="col-md-3 col-sm-12 mt-3">
                <form id="form1" runat="server" method="post" action="WebForm1.aspx">
                    <fieldset>
                        <legend>基本資料輸入</legend>
                        <div class="mb-3">
                            <asp:textbox ID="txtIndex" runat="server" Visible="false"></asp:textbox>
                            <label for="txtName" class="form-label">姓名:</label>
                            <input type="text" runat="server" id="txtName" name="txtName" class="form-control" placeholder="請輸入名字"/>&nbsp;
                            <label for="txtAGE" class="form-label">年齡:</label>
                            <input type="text"  runat="server" name="txtAGE" id="txtAGE" class="form-control" placeholder="請輸入年齡"/>&nbsp;
                            <label for="txtBday" class="form-label">生日:</label>
                            <input type="text" runat="server" name="txtBday"  id="datepicker" class="form-control" validchars="1234567890/" placeholder="請輸入生日" autocomplete="off"/>&nbsp;
                        </div>
                        <div class="mb-3">
                            <asp:Button ID="btnSend" runat="server" class="btn btn-primary" Text="送出檔案" OnClick="btnShow_Click" />
                        </div>
                    </fieldset>
                </form>
            </div>

            <div class="col-md-9 col-sm-12 mt-3">

                <asp:GridView ID="GridView1" OnRowCommand="CustomersGridView_RowCommand" runat="server" howHeader="true" HeaderStyle-HorizontalAlign="Center" CellPadding="10" CellSpacing="5">
                    <HeaderStyle BackColor="LightCyan" ForeColor="MediumBlue" />
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="editItem" Text="編輯"/>
                        <asp:ButtonField ButtonType="Button" CommandName="deleteItem" Text="刪除" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</body>


<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
<script src="https://code.jquery.com/jquery-3.6.0.js"></script>
<script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>

<script>
    $(function () {
       /*  $("#datepicker").datepicker();*/
        /*知識點"UpdatePanel 與 jQuery的衝突"*/
        /*When runat = server is added with a master page then it generate Default style id with master page..So to avoid it try ClientIDMode = "Static"*/
        $("[id$=datepicker]").datepicker();
    });

    function printHello() {
        alert();
    }
</script>


</html>
