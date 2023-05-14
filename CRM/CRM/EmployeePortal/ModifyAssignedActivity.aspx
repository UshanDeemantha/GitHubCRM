 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyAssignedActivity.aspx.cs" Inherits="HRM.EmployeePortal.ModifyAssignedActivity" MasterPageFile="~/Portal.Master" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    <section class="content-header">
        <h1>Modify Job Activities
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
                                       <div class="panel panel-default">
                                            <div class="panel-heading">Job Activities Search</div>
                                            <div class="panel-body">
                                                <div class="row">
                                                          <div class="col-md-2">
                                                                <label for="dxFromDate" id="Label7" style="text-align:center" class="auto-style1">From Date</label>
                                                          </div>
                                                          <div class="col-md-2">
                                                                <dx:ASPxDateEdit ID="dxFromDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                                </dx:ASPxDateEdit>
                                                          </div>
                                                          <div class="col-md-2">
                                                                <label for="dxcbLeadSource" id="Label8" style="text-align:center" class="auto-style1">To Date</label>
                                                          </div>
                                                          <div class="col-md-2">
                                                                <dx:ASPxDateEdit ID="dxToDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                                </dx:ASPxDateEdit>
                                                          </div>
                                                     <div class="col-md-2">
                                                                <label for="txtLeadRenge" id="Label10" style="text-align:center" class="auto-style1">Lead Range</label>
                                                          </div>
                                                    <div class="col-md-2">
                                                        <dx:ASPxTextBox ID="txtLeadRenge" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="50">
                                                        </dx:ASPxTextBox>
                                                        </div>
                                                </div>
                                                    <div class="row">
                                      
                                 <div class="col-md-12">
                                      <div class="box-footer">
                                           <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnClr" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" CausesValidation="False" Text="Clear" OnClick="btnClr_Click">
                                                </dx:ASPxButton>
                                            </div>
                                        <div class="pull-right" style="margin-left: 3px">
                                            <dx:ASPxButton ID="btnSearch" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" CausesValidation="False" Text="Search" OnClick="btnSearch_Click">
                                            </dx:ASPxButton>
                                        </div>


                                          </div>
                                    </div>
                            </div>
                                            </div>
                                       </div>
                        <div class="box box-default">
                            <div class="box-body">
                                <div class="row">
                       
                                    <div class="col-md-2">
                                        <label for="txtLeadName" id="lblUserName" class="auto-style1">Lead No</label>

                                    </div>
                                    <div class="col-md-2">
                                        <dx:ASPxTextBox ID="txtLeadName" BackColor="#F5F5F5" required="" Height="25px" ReadOnly="true" runat="server" Width="100%">
                                       
                                        </dx:ASPxTextBox>
                                    </div>
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-2">
                                        <label for="txtpwRetype" id="Label4" class="auto-style1">Status</label>

                                    </div>
                                    <div class="col-md-2">
                                        <dx:ASPxComboBox ID="cbStatus" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" ValueType="System.String" TextFormatString="{0}" NullText=" << Select Status >> ">
                                            <Items>
                                                <dx:ListEditItem Text="Assigned" Value="2" ImageUrl="~/Images/Assign.png" />
                                                <dx:ListEditItem Text="Confirmed" Value="5" ImageUrl="~/Images/Complete.png" />
                                                <dx:ListEditItem Text="Rejected" Value="4" ImageUrl="~/Images/Reject.png" />
                                                <dx:ListEditItem Text="Pending" Value="3" ImageUrl="~/Images/Pending.png" />
                                            </Items>
                                            <ItemImage Height="17px" IconID="actions_apply_18x18">
                                            </ItemImage>
                                        </dx:ASPxComboBox>
                                    </div>


                                </div>
                                  <div class="row">
                                          <div class="col-md-2">
                                        <label for="txtOwner" id="Label9" class="auto-style1">Customer No</label>

                                    </div>
                                     <div class="col-md-2">
                                    <dx:ASPxTextBox ID="txtCustomerNo" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="50" ReadOnly="true">
                                        </dx:ASPxTextBox>
                                         </div>
                                       
                                       <div class="col-md-2">
                                    </div>
                                      <div class="col-md-2">
                                        <label for="txtComment" id="Label1" class="auto-style1">Comment</label>

                                    </div>
                                    <div class="col-md-4">
                                        <dx:ASPxMemo ID="txtComment" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="120">
                                        </dx:ASPxMemo>
                                    </div>
                                  
                                 </div>
                                <div class="row">
                                <div class="col-md-2">
                                        <label for="txtCutomerNmae" id="Label2" class="auto-style1">Customer Name</label>

                                    </div>
                                    <div class="col-md-3">
                                        <dx:ASPxTextBox ID="txtCutomerNmae" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="50">
                                        </dx:ASPxTextBox>
                                    </div>
                                       <div class="col-md-1">
                                           </div>
                                       <div class="col-md-2">
                                        <label for="dxcomActivity" id="Label5" class="auto-style1">Job Activity</label>
                                    </div>
                                    <div class="col-md-3">
                                        <dx:ASPxComboBox ID="dxcomActivity" BackColor="#F5F5F5" Height="25px" required="" Width="100%" runat="server" DropDownStyle="DropDownList" DataSourceID="SqlDsActivity"
                                            ValueField="Type" ValueType="System.String" TextFormatString="{0}" NullText=" << Select Job Activity >> " MaxLength="50" ReadOnly="true">
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="Type" Width="100px" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                    </div>

                                    </div>
                                <div class="row">
                                        <div class="col-md-2">
                                        <label for="txtOwner" id="lbltxtOwner" class="auto-style1">Executive Name</label>

                                    </div>
                                    <div class="col-md-3">
                                        <dx:ASPxComboBox ID="txtOwner" BackColor="#F5F5F5" Height="25px" required="" Width="100%" runat="server" DropDownStyle="DropDownList" DataSourceID="SqlDsowner" ReadOnly="true"
                                            ValueField="ExecutiveId" ValueType="System.String" TextFormatString="{0}" MaxLength="50">
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="Name" Width="100px" />
                                            </Columns>
                                        </dx:ASPxComboBox>

                                        <asp:SqlDataSource ID="SqlDsowner" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                              SelectCommand="SELECT [ExecutiveId], [EPFNo], [Name]+'/'+[LocationName] as Name FROM [CRM_ExecutiveDetails] INNER JOIN
                                                    CRM_Location ON CRM_ExecutiveDetails.LocationId = CRM_Location.LocationId  WHERE Active= '1' AND CRM_ExecutiveDetails.LocationId=@LocationId ">
                                            <SelectParameters>
                                                    <asp:SessionParameter Name="LocationId" SessionField="LocationId" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                    <div class="col-md-1">
                                           </div>
                                
                                    <div class="col-md-2">
                                        <label for="txtActOwner" id="Label6" class="auto-style1">Due Date</label>
                                    </div>
                                    <div class="col-md-2">
                                        <dx:ASPxDateEdit ID="dtStartDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="yyyy-MM-dd" EditFormatString="yyyy-MM-dd">
                                        </dx:ASPxDateEdit>
                                    </div>

                                </div>
                                <div class="row">
                                      <div class="col-md-2">
                                        <label for="txtProduct" id="Label3" class="auto-style1">Product</label>

                                    </div>
                                    <div class="col-md-3">
                                        <dx:ASPxMemo ID="txtProduct" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" MaxLength="250">
                                        </dx:ASPxMemo>
                                    </div>
                                    
                                    <div class="col-md-1">
                                        </div>

                                           <div class="col-md-2">
                                 <dx:ASPxCheckBox ID="cbQuotation" runat="server" Text="Quotation" Font-Bold="true" AutoPostBack="true" Checked="false" OnCheckedChanged="cbQuotation_CheckedChanged"></dx:ASPxCheckBox>
                                 </div>
                                     <div class="col-md-3">
                                          <dx:ASPxTextBox ID="txtQuotation" BackColor="#F5F5F5"  Height="25px" runat="server" Width="100px" Visible="false" HorizontalAlign="Center">
                                        
                                        </dx:ASPxTextBox>
                                         </div>
                                </div>
                               
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box-footer">

                                            <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnClear" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" CausesValidation="False" Text="Cancel" OnClick="btnClear_Click">
                                                </dx:ASPxButton>
                                            </div>


                                            <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnAdd" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" Width="100px" Text="Update" OnClick="btnAdd_Click">
                                                </dx:ASPxButton>
                                            </div>
                                                 <div class="pull-right" style="margin-left: 3px">
                                            <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                               
                                <div class="row">
                                    <div class="col-md-12">

                                        <dx:ASPxGridView ID="gvAssignActivity" runat="server" AutoGenerateColumns="False" Font-Size="Small" CssClass="col-md-12" 
                                            ClientIDMode="AutoID" EnableTheming="True" KeyFieldName="Id" Theme="MetropolisBlue" Width="100%"  OnHtmlDataCellPrepared="Grid_HtmlDataCellPrepared" OnHtmlRowPrepared="gvAssignActivity_HtmlRowPrepared">
                                            <SettingsPager PageSize="15">
                                            </SettingsPager>
                                            <Settings HorizontalScrollBarMode="Auto"  />
                                          
                                            <SettingsSearchPanel Visible="true" HighlightResults="true" />
                                            <SettingsBehavior AllowFocusedRow="true" />
                                            <Columns>

                                                <dx:GridViewDataTextColumn FieldName="Id" Caption="Id" VisibleIndex="1" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="LeadName" Caption="Lead No" VisibleIndex="2" Width="80px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn> 
                                                <dx:GridViewDataCheckColumn FieldName="IsQuootation" Caption="Quotation" VisibleIndex="11" Width="80px" >
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataTextColumn FieldName="QuotationNo" Caption="Quotation No" VisibleIndex="13" Width="120px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn> 
                                                 <dx:GridViewDataCheckColumn FieldName="IsMessageSend" Caption="SMS Not Send" VisibleIndex="14" Width="100px" >
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer Name" VisibleIndex="5" Width="250px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Address" Caption="Address" VisibleIndex="6" Width="350px">
                                                </dx:GridViewDataTextColumn>
                                                  <dx:GridViewDataTextColumn FieldName="ProductList" Caption="Products List" VisibleIndex="9" Width="250px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ContactNo" Caption="Customer No" VisibleIndex="7" Width="100px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Subject" Caption="Description" VisibleIndex="10" Width="150px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Activity" Caption="Job Activity " VisibleIndex="15" Width="150px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Executive Name" VisibleIndex="8" Width="160px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Comment" Caption="Comment" VisibleIndex="11" Width="150px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ActivityOwnerId" Caption="Activity Owner" VisibleIndex="9" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CustomerId" Caption="Activity Owner" VisibleIndex="12" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DueDate" Settings-GroupInterval="Value" Caption="Due Date" VisibleIndex="16" Width="80px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd">
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn FieldName="CreatedDate" Settings-GroupInterval="Value" Caption="Job Date" VisibleIndex="4" Width="80px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd">
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="LeadStatus" Caption="Status" VisibleIndex="3" Width="80px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn FieldName="Pyament" Caption="Payment Status" VisibleIndex="17" Width="120px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn VisibleIndex="1" Width="70px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                    <DataItemTemplate>
                                                        <dx:ASPxButton ID="btnEdit" runat="server" RenderMode="Link" OnInit="btnEdit_Init"
                                                            Width="60px" Height="20px" Text="Edit" AutoPostBack="false" ImagePosition="Right" OnClick="btnEdit_Click">
                                                            <Image IconID="edit_edit_16x16"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnDelete" runat="server" RenderMode="Link" Visible="false"
                                                            Width="60px" Height="20px" Text="Delete" AutoPostBack="false" ImagePosition="Right" OnClick="btnDelete_Click">
                                                            <Image IconID="edit_delete_16x16"></Image>
                                                        </dx:ASPxButton>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataColumn>

                                            </Columns>
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
                                            <asp:Button ID="Button1" runat="server" Height="30px" Width="120px" Text="Yes" OnClick="Button1_Click" CssClass="btn btn-block btn-success btn-large" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>

    <asp:HiddenField ID="hfAssignLeadId" runat="server" />
    <asp:SqlDataSource ID="SqlDsActivity" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT [Type], [Description], [Active] FROM [CRM_ActivityType]  WHERE Active='1'"></asp:SqlDataSource>

</asp:Content>
