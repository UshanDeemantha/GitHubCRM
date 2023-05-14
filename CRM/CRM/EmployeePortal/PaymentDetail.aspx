<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentDetail.aspx.cs" Inherits="HRM.EmployeePortal.PaymentDetail" MasterPageFile="~/Portal.Master" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   

    <style type="text/css">
        .auto-style1 {
             Width:100%;
            height: 30px;
            font-family:Verdana;
            text-align:left;
            
        }
         </style>
     <script>
         function show() {
             $('#exampleModal').modal('toggle');
         }
         function close() {
             document.getElementById('exampleModal').className = 'hiddendiv';
         }
    </script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
          <h1>Payments Detials
           </h1>
         
     </section>

    <section class="content">

                 <div class="box box-default">
                    <div class="box-body">
                        <div class="row">
                             <div class="col-md-2">
                                <label for="txtLeadName" id="lblUserName" class="auto-style1">Lead No</label>
                            </div>
                            <div class="col-md-2">
                                <dx:ASPxTextBox ID="txtLeadName" BackColor="#F5F5F5"  Height="25px" runat="server" Width="100%" HorizontalAlign="Center" >
                                </dx:ASPxTextBox>
                            </div>
                             <div class="col-md-2">
                                 </div>
                             <div class="col-md-2">
                                <label for="txtQuoName" id="lblQuo" class="auto-style1">Quotation No</label>
                            </div>
                            <div class="col-md-2">
                                <dx:ASPxTextBox ID="txtQuoName" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" HorizontalAlign="Center" >
                                </dx:ASPxTextBox>
                            </div>
                                    
                      
                       </div>

                        <div class="row">
                             <div class="col-md-2">
                                <label for="txtSPName" id="lblSP" class="auto-style1">Executive Name</label>
                            </div>
                            <div class="col-md-3">
                                <dx:ASPxComboBox ID="dxCbSalesPerson" BackColor="#F5F5F5" Height="25px" Width="100%" runat="server" DropDownStyle="DropDownList" DataSourceID="SqlDxSalesPerson"
                                                    ValueField="ExecutiveId"  ValueType="System.String" TextFormatString="{0}" NullText=" << Select Executive >> " MaxLength="50">

                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="Name" Caption="Executive Name"  Width="100px" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="SqlDxSalesPerson" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                    SelectCommand="SELECT [Name],[ExecutiveId] FROM [CRM_ExecutiveDetails]WHERE Active= '1' AND CRM_ExecutiveDetails.LocationId=@LocationId ">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="LocationId" SessionField="LocationId" Type="Int32" />
                                    </SelectParameters>
                               </asp:SqlDataSource>
                            </div>
                             
                            <div class="col-md-1">
                                </div>
                             <div class="col-md-2">
                                <label for="txtCName" id="lblCN" class="auto-style1">Customer Name</label>
                            </div>
                            <div class="col-md-3">
                                <dx:ASPxComboBox ID="dxCbCustomer" BackColor="#F5F5F5"  Height="25px" Width="100%" runat="server" DropDownStyle="DropDownList" DataSourceID="SqlDxCustomer"
                                                    ValueField="CustomerId"  ValueType="System.String" TextFormatString="{0}" NullText=" << Select Customer >> " MaxLength="50">

                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="FirstName" Caption="Customer Name"  Width="100px" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="SqlDxCustomer" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                    SelectCommand="SELECT  CRM_Customer.NameTitle+''+CRM_Customer.FirstName as FirstName,[CustomerId] FROM [CRM_Customer]"></asp:SqlDataSource>
                            </div>
                                    
                      
                       </div>

                           <div class="row">
                                    <div class="col-md-12">
                                        <div class="box-footer">
                                            <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnClear" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" CausesValidation="False" Text="Clear" OnClick="btnClear_Click">
                                                </dx:ASPxButton>
                                            </div>


                                            <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnSearch" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" Width="100px" Text="Search" OnClick="btnSearch_Click">
                                                    <Paddings Padding="1px" />
                                                </dx:ASPxButton>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                        </div>
                            
                        </div>

                    <dx:ASPxGridView ID="gvViewCustomerPayment" runat="server" AutoGenerateColumns="False" Font-Size ="Small"  CssClass="col-md-12" OnHtmlRowPrepared="gvViewCustomerPayment_HtmlRowPrepared"
                                        ClientIDMode="AutoID" EnableTheming="True" KeyFieldName="PaymentId" Theme="MetropolisBlue" Width="100%" Settings-HorizontalScrollBarMode="Auto">
                                        <SettingsPager PageSize="50">
                                        </SettingsPager>
                                        <SettingsSearchPanel Visible="true" HighlightResults="true" />
                                               <SettingsBehavior AllowFocusedRow="true" />
                                        <Columns>

                                         <dx:GridViewDataTextColumn FieldName="LeadNo" Caption="Lead No" VisibleIndex="2" Width="80px">
                                             <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                              <dx:GridViewDataTextColumn FieldName="PaymentId" Caption="PaymentId" VisibleIndex="1" Width="80px" Visible="false">
                                             <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="QuotationNo" Caption="Quotation No" VisibleIndex="3" Width="120px" >
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Name" Caption="Executive" VisibleIndex="8" Width="220px">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="4"  Width="300px">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Payment"  Caption="Payment Type"  VisibleIndex="5" Width="130px">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Description"  Caption="Payment Method"  VisibleIndex="9" Width="120px">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="Amount"  Caption="Amount (LKR)"  VisibleIndex="7" Width="100px">
                                                 <CellStyle HorizontalAlign="right" />
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="ChequeDetail"  Caption="Cheque Details"  VisibleIndex="11" Width="200px">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="DirectDetails"  Caption="Direct Deposite"  VisibleIndex="10" Width="200px">
                                            </dx:GridViewDataTextColumn>
                                              <dx:GridViewDataTextColumn FieldName="PaymentDate" Caption="Payment Date" VisibleIndex="6" Width="100px">
                                                  <CellStyle HorizontalAlign="Center" />
                                                <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CreatedUser"  Caption="User"  VisibleIndex="12" Width="100px">
                                                  <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataColumn VisibleIndex="1" Width="140px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                    <DataItemTemplate>
                                                        <dx:ASPxButton ID="btnEdit" runat="server" RenderMode="Link"  
                                                            Width="60px" Height="20px" Text="Edit" AutoPostBack="false"  ImagePosition="Right" OnClick="btnEdit_Click">
                                                            <Image IconID="edit_edit_16x16"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnDelete" runat="server" RenderMode="Link"
                                                            Width="60px" Height="20px" Text="Delete" AutoPostBack="false" ImagePosition="Right" OnClick="btnDelete_Click">
                                                            <Image IconID="edit_delete_16x16"></Image>
                                                        </dx:ASPxButton>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                            

                                        </Columns>
                                          <Styles>
                                            <Header BackColor="WindowFrame" Font-Bold="true" HorizontalAlign="Center">
                                            </Header>
                                            <Cell HorizontalAlign="left"></Cell>
                                            <AlternatingRow BackColor="#F5F5F5">
                                            </AlternatingRow>
                                         </Styles>

                                    </dx:ASPxGridView>

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
    </section>

</asp:Content>

