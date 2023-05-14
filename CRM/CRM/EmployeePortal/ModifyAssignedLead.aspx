<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyAssignedLead.aspx.cs" Inherits="HRM.EmployeePortal.ModifyAssignedLead" MasterPageFile="~/Portal.Master" %>


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

        <h1>Modify Customer</h1>


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

                            <%--        <div class="col-md-2">
                                        <label for="txtLeadName" id="lblUserName" class="auto-style1" style="text-align: center">Lead No</label>

                                    </div>
                                    <div class="col-md-2">
                                        <dx:ASPxTextBox ID="txtLeadName" BackColor="#F5F5F5" required="" Height="25px" ReadOnly="true" runat="server" Width="100%" HorizontalAlign="Center">
                                        
                                        </dx:ASPxTextBox>
                                    </div>

                                    <div class="col-md-1">
                                        <label for="txtpwRetype" id="Label4" class="auto-style1">Status</label>

                                    </div>
                                    <div class="col-md-2">
                                        <dx:ASPxComboBox ID="cbStatus" BackColor="#F5F5F5" runat="server" Height="25px" Width="100%" ValueType="System.String" TextFormatString="{0}" NullText=" << Select Status >> ">
                                            <Items>

                                                <dx:ListEditItem Text="Assigned" Value="2" ImageUrl="~/Images/Assign.png" />
                                                <dx:ListEditItem Text="Won" Value="6" ImageUrl="~/Images/Won.png" />
                                                <dx:ListEditItem Text="Lost" Value="7" ImageUrl="~/Images/Reject.png" />
                                            </Items>
                                            <ItemImage Height="15px" IconID="actions_apply_16x16">
                                            </ItemImage>
                                        
                                        </dx:ASPxComboBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label for="txtComment" id="Label1" class="auto-style1">Comment</label>

                                    </div>
                                    <div class="col-md-3">
                                        <dx:ASPxMemo ID="txtComment" BackColor="#F5F5F5" required="" Height="25px" runat="server" Width="100%" MaxLength="120">
                                        </dx:ASPxMemo>
                                    </div>
                                </div>
                                 <div class="row">
                                      <div class="col-md-8">
                                </div>
                                  <div class="col-md-1">
                                 <dx:ASPxCheckBox ID="cbQuotation" runat="server" Text="Quotation" AutoPostBack="true" Checked="false" OnCheckedChanged="cbQuotation_CheckedChanged"></dx:ASPxCheckBox>
                                 </div>
                                     <div class="col-md-2">
                                          <dx:ASPxTextBox ID="txtQuotation" BackColor="#F5F5F5"  Height="25px" runat="server" Width="100px" Visible="false" HorizontalAlign="Center">
                                        
                                        </dx:ASPxTextBox>
                                         </div>
                                 </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box-footer">
                                          
                                            <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnClear" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px"  Text="Cancel" OnClick="btnClear_Click">
                                                </dx:ASPxButton>
                                            </div>


                                            <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnAdd" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" Width="100px" Text="Update" OnClick="btnAdd_Click">
                                                    <Paddings Padding="1px" />
                                                </dx:ASPxButton>
                                            </div>
                                                 <div class="pull-right" style="margin-left: 3px">
                                            <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>

                                            </div>

                                        </div>
                                    </div>
                                </div>--%>
                                <div class="row">
                                    <div class="col-md-12">
                                        <dx:ASPxGridView ID="gvAssignLead" runat="server" AutoGenerateColumns="False" Font-Size="Small" DataSourceID="dsAssignLead" CssClass="col-md-12"
                                            ClientIDMode="AutoID" EnableTheming="True" KeyFieldName="LeadNo" Theme="MetropolisBlue" Width="98%">
                                            <SettingsPager PageSize="50">
                                            </SettingsPager>
                                            <SettingsSearchPanel Visible="true" HighlightResults="true" />
                                            <SettingsBehavior AllowFocusedRow="true" />
                                            <Columns>

                                                 <dx:GridViewDataTextColumn FieldName="CustomerId" Caption="Id" VisibleIndex="1" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="IsQuootation" Caption="Id" VisibleIndex="2" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="LeadNo" Caption="Lead No" VisibleIndex="2" Width="100px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer Name" VisibleIndex="3" Width="250px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ContactNo" Caption="Customer No" VisibleIndex="4" Width="100px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn FieldName="Address" Caption="Customer Address" VisibleIndex="5" Width="250px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="QuotationNo" Caption="Quotation" VisibleIndex="6" Width="100px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pyament" Caption="Payments" VisibleIndex="7" Width="120px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn VisibleIndex="1" Width="140px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                    <DataItemTemplate>
                                                        <dx:ASPxButton ID="btnEdit" runat="server" RenderMode="Link" Visible="false" 
                                                            Width="60px" Height="20px" Text="Edit" AutoPostBack="false"  ImagePosition="Right" OnInit="btnEdit_Init" OnClick="btnEdit_Click">
                                                            <Image IconID="edit_edit_16x16"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnviewLead" runat="server" RenderMode="Link"
                                                            Width="60px" Height="20px" Text="View" AutoPostBack="false" ImagePosition="Right" OnClick="btnviewLead_Click">
                                                            <Image IconID="navigation_backward_16x16"></Image>
                                                        </dx:ASPxButton>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataColumn>

                                            </Columns>
                                            
                                            <Styles>
                                                <Header BackColor="WindowFrame" Font-Bold="true" HorizontalAlign="Center">
                                                </Header>
                                                <Cell HorizontalAlign="left"></Cell>
                                                <AlternatingRow BackColor="">
                                                </AlternatingRow>
                                            </Styles>

                                            <Border BorderStyle="Outset" />

                                        </dx:ASPxGridView>

                                    </div>

                                </div>

                            </div>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
    <asp:HiddenField ID="hfAssignLeadId" runat="server" />
    <asp:SqlDataSource ID="dsAssignLead" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="CRM_GetAssignedLeads" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="EmployeeId" Type="Int64" />
             <asp:SessionParameter Name="LocationId" SessionField="LocationId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
