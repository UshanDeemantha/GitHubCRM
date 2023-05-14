<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeadRegistration.aspx.cs" Inherits="HRM.EmployeePortal.LeadRegistration" MasterPageFile="~/Portal.Master" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function onValidation(s, e) {

            e.isValid = true;
            //if (s.GetValue().trim().length == 0) {


            //}
        }
    </script>

    <style type="text/css">
        .auto-style1 {
            Width: 100%;
            height: 30px;
            font-family: Verdana;
            text-align: left;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <section class="content-header">
            <h1>Customer Leads Registration
           <%-- <small>Advanced form element</small>--%>
            </h1>

        </section>
        <section class="content">
            <div class='row'>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class='col-md-12'>
                            <div class="alert alert-danger slide in" id="popDiv" runat="server">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <strong><i class="icon fa fa-ban"></i>Alert! </strong>
                                <asp:Label ID="lberror" runat="server"></asp:Label>


                            </div>
                            <div class="alert alert-success alert-dismissable" id="popDivv" runat="server">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <strong><i class="icon fa fa-check"></i>Alert! </strong>
                                <asp:Label ID="lbSuccess" runat="server"></asp:Label>
                            </div>

                            <div class="box box-default">
                                <div class="box-body">
                                    <div class="row">

                                        <div class="col-md-2">
                                            <label for="txtLeadNo" id="lblLeadNo" style="text-align: center" class="auto-style1">Lead No</label>
                                        </div>
                                        <div class="col-md-2">
                                            <dx:ASPxTextBox ID="txtLeadNo" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="10" ReadOnly="true" HorizontalAlign="Center">
                                            </dx:ASPxTextBox>
                                        </div>


                                        <div class="col-md-2">
                                            <label for="dxcbLeadSource" id="lblLeadSource" style="text-align: center" class="auto-style1">Lead Source</label>
                                        </div>
                                        <div class="col-md-2">
                                            <dx:ASPxComboBox ID="dxcbLeadSource" Height="25px" BackColor="#F5F5F5" Width="100%" runat="server" DropDownStyle="DropDownList"
                                                ValueType="System.String" TextFormatString="{0}" MaxLength="50">
                                                <Items>
                                                    <dx:ListEditItem Text="By Calling" Value="1"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="By Mailing" Value="2"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="By Walking" Value="3"></dx:ListEditItem>
                                                </Items>
                                                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right">
                                                    <RequiredField IsRequired="true" ErrorText="Lead Source is required" />
                                                </ValidationSettings>
                                                <InvalidStyle BackColor="LightPink" />
                                            </dx:ASPxComboBox>
                                        </div>
                                        <div class="col-md-2">
                                            <label for="dtStartDate" id="Label3" style="text-align: center" class="auto-style1">Lead Date</label>
                                        </div>
                                        <div class="col-md-2">
                                            <dx:ASPxDateEdit ID="dtStartDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" HorizontalAlign="Center">
                                            </dx:ASPxDateEdit>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-10">
                                        </div>
                                        <div class="col-md-2">
                                            <dx:ASPxCheckBox ID="cbQuotation" runat="server" Text="Only Quotation" Checked="false" Visible="false"></dx:ASPxCheckBox>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">Customer Details</div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label for="txtContactNo" id="lblContactNo" class="auto-style1">Contact No 1</label>
                                                </div>

                                                <div class="col-md-2">
                                                    <dx:ASPxTextBox ID="txtContactNo" BackColor="#F5F5F5" Height="25px" runat="server" 
                                                        AutoPostBack="true" OnTextChanged="txtContactNo_TextChanged">
                                                        <MaskSettings Mask="0000000000" />
                                                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="true" ErrorText="Contact No is required" />
                                                        </ValidationSettings>
                                                        <InvalidStyle BackColor="LightPink" />
                                                    </dx:ASPxTextBox>
                                               
                                                </div>
                                                 <div class="col-md-2">
                                                         <dx:ASPxButton ID="btnPRVICOM" runat="server"  RenderMode="Link"   Visible="false" ImagePosition="Left" OnClick="btnPRVICOM_Click">
                                                            <Image Url="Images/PRI4.png"></Image>
                                                        </dx:ASPxButton>
                                                    
                                                         <dx:ASPxButton ID="btnNEXTCOM" runat="server" RenderMode="Link"  Paddings-PaddingRight="5px"  Visible="false" ImagePosition="Left" OnClick="btnNEXTCOM_Click">
                                                            <Image Url="Images/NEXT9.png"></Image>
                                                        </dx:ASPxButton>
                                                    
                                                        <dx:ASPxButton ID="btnADDCOM" runat="server" RenderMode="Link"   Visible="false" ImagePosition="Left" OnClick="btnADDCOM_Click">
                                                            <Image Url="Images/ADD8.png"></Image>
                                                        </dx:ASPxButton>
                                                     </div>


                                    
                                                
                                                <div class="col-md-2">
                                                    <label for="txtContactNo2" id="Label1" class="auto-style1">Contact No 2</label>
                                                </div>

                                                <div class="col-md-2">
                                                    <dx:ASPxTextBox ID="txtContactNo2" ClientSideEvents-Validation="onValidation" BackColor="#F5F5F5" Height="25px" runat="server" Width="100px">
                                                        <MaskSettings Mask="0000000000" />
                                                    </dx:ASPxTextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <dx:ASPxCheckBox ID="CBChange" runat="server" Text="Change Contact" Checked="false" OnCheckedChanged="CBChange_CheckedChanged" AutoPostBack="true" Visible="false"></dx:ASPxCheckBox>
                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-md-1">
                                                    <label for="txtName" id="lblName" class="auto-style1">Customer</label>
                                                </div>
                                                <div class="col-md-1">
                                                    <dx:ASPxComboBox ID="cbMR" Height="25px" BackColor="#F5F5F5" Width="60px" runat="server" DropDownStyle="DropDownList"
                                                        ValueType="System.String" TextFormatString="{0}">
                                                        <Items>
                                                            <dx:ListEditItem Text="Mr." Value="0"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Mrs." Value="1"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Miss." Value="2"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Dr." Value="3"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Rev." Value="4"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Rev.Fr." Value="5"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Prof." Value="6"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Arch." Value="7"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Com." Value="8"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Site." Value="9"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Ven." Value="10"></dx:ListEditItem>
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <dx:ASPxTextBox ID="txtName" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="50">
                                                       
                                                    </dx:ASPxTextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <label for="txtName2" id="Label2" class="auto-style1">Customer Name 2</label>
                                                </div>
                                                <div class="col-md-4">
                                                    <dx:ASPxTextBox ID="txtName2" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="50">
                                                    </dx:ASPxTextBox>
                                                </div>


                                            </div>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label for="txtAddress" id="lblAddress" class="auto-style1">Address</label>
                                                </div>
                                                <div class="col-md-4">
                                                    <dx:ASPxMemo ID="txtAddress" BackColor="#F5F5F5" Height="35px" runat="server" Width="100%" MaxLength="150">
                                                    </dx:ASPxMemo>
                                                </div>
                                                <div class="col-md-2">
                                                    <label for="txtSpecialInstruction" id="lblSpecialInstruction" class="auto-style1">Remark</label>
                                                </div>
                                                <div class="col-md-4">
                                                    <dx:ASPxMemo ID="txtSpecialInstruction" BackColor="#F5F5F5" Height="35px" runat="server" Width="100%" MaxLength="100">
                                                    </dx:ASPxMemo>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:Label ID="Label4" runat="server" Text="Please Verify Customer" Visible="false" ForeColor="Red"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <dx:ASPxCheckBox ID="dxCheckBox" runat="server" Text="Verified Customer Details" Checked="false"></dx:ASPxCheckBox>
                                                </div>

                                            </div>

                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">Product Details</div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        <label for="dxCbProductName" id="lblProductName" class="auto-style1">Product Name</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <dx:ASPxComboBox ID="dxCbProductName" Height="25px" BackColor="#F5F5F5" Width="220%" runat="server" DropDownStyle="DropDownList" DataSourceID="sqldsProductName"
                                                            ValueField="ItemId" ValueType="System.String" TextFormatString="{0}" NullText="  << Select Product Name >> ">
                                                            <Columns>
                                                                <dx:ListBoxColumn FieldName="Name" Width="100px" />
                                                            </Columns>


                                                        </dx:ASPxComboBox>

                                                        <asp:SqlDataSource ID="sqldsProductName" runat="server"
                                                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                            SelectCommand="SELECT [ItemId], [Name],[Active] FROM [CRM_ItemMaster] WHERE Active='1' "></asp:SqlDataSource>
                                                    </div>
                                                    <div class="col-md-2">
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label for="ASPxProductDes" id="lblProductDescription" class="auto-style1">Description</label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <dx:ASPxMemo ID="ASPxProductDes" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="100">
                                                        </dx:ASPxMemo>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        <label for="txtquantity" id="lblquantity" class="auto-style1">Quantity</label>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <dx:ASPxTextBox ID="txtquantity" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="10" HorizontalAlign="Center">
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                    <div class="col-md-3">
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label for="ASPxComment" id="lblComment" class="auto-style1">Comment</label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <dx:ASPxMemo ID="ASPxComment" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="150">
                                                        </dx:ASPxMemo>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="box-footer">
                                                            <div class="pull-right" style="margin-left: 3px">
                                                                <dx:ASPxButton ID="btnClear" Width="80px" Height="20px" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" Text="Clear" OnClick="btnClear_Click">
                                                                </dx:ASPxButton>
                                                            </div>
                                                            <div class="pull-right" style="margin-left: 3px; height: 20px;">
                                                                <dx:ASPxButton ID="btnAdd" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" Width="80px" Height="20px" Text="Add" OnClick="btnAdd_Click">
                                                                </dx:ASPxButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <dx:ASPxGridView ID="gvProductDetails" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                                                            ClientIDMode="AutoID" EnableTheming="True" Theme="MetropolisBlue" Width="100%">
                                                            <SettingsPager PageSize="10">
                                                            </SettingsPager>
                                                            <%--<SettingsSearchPanel Visible="true" HighlightResults="true"  />--%>
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="ProductName" Caption="Product Name" VisibleIndex="0">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ProductDescription" Caption="Description" VisibleIndex="1">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Quantity" Caption="Quantity" VisibleIndex="3" Width="50px">
                                                                    <CellStyle HorizontalAlign="Center" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Comment" Caption="Comment" VisibleIndex="2">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ProductId" Caption="Comment " VisibleIndex="7" Visible="false">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Id" Caption="id " VisibleIndex="4" Visible="false">
                                                                </dx:GridViewDataTextColumn>
                                                                 <dx:GridViewDataTextColumn FieldName="LeadDetailId" Caption="LeadDetailId " VisibleIndex="4" Visible="false">
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn VisibleIndex="5" Width="130px">
                                                                    <CellStyle HorizontalAlign="Center" />
                                                                    <DataItemTemplate>
                                                                        <dx:ASPxButton ID="btnEdit" runat="server" RenderMode="Link"
                                                                            Width="55px" Height="25px" Text="Edit" AutoPostBack="false" ImagePosition="Right" OnClick="btnEdit_Click">
                                                                            <Image IconID="edit_edit_16x16"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton ID="btnDelete" runat="server" RenderMode="Link"
                                                                            Width="55px" Height="25px" Text="Delete" AutoPostBack="false" ImagePosition="Right" OnClick="btnDelete_Click">
                                                                            <Image IconID="edit_delete_16x16"></Image>
                                                                        </dx:ASPxButton>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataTextColumn>

                                                            </Columns>
                                                            <SettingsEditing EditFormColumnCount="2">
                                                            </SettingsEditing>

                                                            <Styles>
                                                                <Header BackColor="WindowFrame" Font-Bold="true" HorizontalAlign="Center">
                                                                </Header>
                                                                <Cell HorizontalAlign="Left"></Cell>
                                                                <AlternatingRow BackColor="#F5F5F5">
                                                                </AlternatingRow>
                                                            </Styles>

                                                        </dx:ASPxGridView>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">

                                                <div class="box-footer">
                                                    <div class="pull-right" style="margin-left: 3px">
                                                        <dx:ASPxButton ID="btnClear1" Width="80px" Height="20px" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" Text="Cancel" OnClick="btnClear1_Click">
                                                        </dx:ASPxButton>
                                                    </div>
                                                    <div class="pull-right" style="margin-left: 25px">
                                                        <dx:ASPxButton ID="btnSave" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" Width="80px" Height="20px" Text="Save" OnClick="btnSave_Click">
                                                        </dx:ASPxButton>
                                                    </div>
                                                         <div class="pull-right" style="margin-left: 3px">
                                            <asp:Label ID="lblResult" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>

                                            </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <dx:ASPxPopupControl ID="confirmpopup" runat="server" HeaderText="Confirm Message" Height="100px" PopupHorizontalAlign="WindowCenter" Width="300px" PopupVerticalAlign="WindowCenter">
                                    <HeaderTemplate>
                                        Confirm Message
                                    </HeaderTemplate>
                                    <ContentCollection>
                                        <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">




                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="auto-style10" colspan="3">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style10" colspan="3" style="font-size: medium; font-weight: bold; font-family: Arial, Helvetica, sans-serif; font-style: normal;">Are you sure you want to Delete?</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style10">&nbsp;</td>
                                                    <td></td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="auto-style7">
                                                        <asp:Button ID="Button1" runat="server" Height="30px" Width="120px" Text="Yes" OnClick="btnDelete_Click1" CssClass="btn btn-block btn-success btn-large" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="Button3" runat="server" Height="30px" Width="120px" Text="No" OnClick="btnDeleteNo_Click" CssClass="btn btn-block btn-warning btn-large" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style7">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>




                                        </dx:PopupControlContentControl>


                                    </ContentCollection>
                                </dx:ASPxPopupControl>

                                <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"  HeaderText="Confirm Message" Height="100px" PopupHorizontalAlign="WindowCenter" Width="200px" PopupVerticalAlign="WindowCenter">
                                    <HeaderTemplate>
                                        Customer Leads Registration 
                                    </HeaderTemplate>
                                    
                                                                        <ContentCollection>
                                        <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">

                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="auto-style10" colspan="3" style="font-size: medium; font-weight: bold; font-family: Arial, Helvetica, sans-serif; font-style: normal; text-align: center">Lead No &nbsp;
                                                                <label id="Label5" runat="server"></label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td class="auto-style7">
                                                        <asp:Button ID="Ok1" runat="server" Height="30px" Width="50px" Text="OK" OnClick="btnOk_Click1" CssClass="btn btn-block btn-success btn-large" Font-Size="Small" />
                                                    </td>
                                                </tr>
                                            </table>

                                        </dx:PopupControlContentControl>


                                    </ContentCollection>
                                </dx:ASPxPopupControl>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
        <asp:HiddenField ID="hfLeadDetailId" runat="server" />

    </div>
</asp:Content>
