<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssigningLeads.aspx.cs" Inherits="HRM.EmployeePortal.AssigningLeads" MasterPageFile="~/Portal.Master" %>

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
            <h1> Assign Customer Leads
           <%-- <small>Advanced form element</small>--%>
            </h1>
            <ol class="breadcrumb">
               <%-- <li><a href="Default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>--%>

                      <li>
                        <asp:LinkButton ID="lkSearchLeads" runat="server" OnClick="lkSearchLeads_Click" Visible="false">Search Customer Leads</asp:LinkButton>

                    </li>
                <%--   <li><a href="#">Forms</a></li>--%>
            </ol>
        </section>
            <section class="content">
                <div class='row'>
         
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

                             <div class="alert alert-warning" id="popDivvv" runat="server">
                                <a href="#" class="close" data-dismiss="alert"  aria-label="close">&times;</a>
                                <strong><i class="icon fa fa-check"></i>Alert! </strong>
                                <asp:Label ID="lbwarning" runat="server"></asp:Label>
                            </div>
                            </div>
                    </div>
                <div class="box box-default">
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">

                                <div class="col-md-2">
                                    <label for="txtLeadName" id="lblUserName" class="auto-style1">Lead No</label></div>
                                <div class="col-md-2">
                                    <dx:ASPxTextBox ID="txtLeadName" BackColor="#F5F5F5" Height="23px" runat="server" Width="100%" ReadOnly="true">
                                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="true" ErrorText="Lead No is required" />
                                        </ValidationSettings>
                                        <InvalidStyle BackColor="LightPink" />
                                    </dx:ASPxTextBox>
                                </div>
                                <div class="col-md-1">
                                   
                                <asp:Button ID="Button1" runat="server" class="btn btn-info" Text="Search" Height="35px" OnClick="Button1_Click"  />
                                

                            </div>
                                </div>
                            </div>
                        <div class="row">
                            <div class="col-md-12">

                                <div class="col-md-2">
                                    <label for="txtpw" id="Label1" class="auto-style1">Contact No 1</label></div>
                                <div class="col-md-2">
                                    <dx:ASPxTextBox ID="txtPhone" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" ReadOnly="true" >
                                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="true" ErrorText="Contact No is required" />
                                        </ValidationSettings>
                                        <InvalidStyle BackColor="LightPink" />
                                    </dx:ASPxTextBox>
                                </div>
                                

                            </div>
                            </div>
                        <div class="row">
                              <div class="col-md-12">

                                <div class="col-md-2">
                                    <label for="txtpw" id="Label5" class="auto-style1">Contact No 2</label></div>
                                <div class="col-md-2">
                                    <dx:ASPxTextBox ID="txtPhone2" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" ReadOnly="true" >
                                       
                                        <InvalidStyle BackColor="LightPink" />
                                    </dx:ASPxTextBox>
                                </div>
                                 <div class="col-md-1">
                                 <dx:ASPxCheckBox ID="cbQuotation" runat="server" Text="Quotation" AutoPostBack="true" Checked="false" OnCheckedChanged="cbQuotation_CheckedChanged"></dx:ASPxCheckBox>
                                 </div>
                                  <div class="col-md-6">
                                            <asp:Label ID="lblResult" Text="Message will not sent to Executive." runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>

                                 </div>



                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-12">

                                <div class="col-md-2">
                                    <label for="txtpwRetype" id="Label2" class="auto-style1">Customer Name</label>

                                </div>
                                <div class="col-md-4">
                                    <dx:ASPxTextBox ID="txtCusName" BackColor="#F5F5F5" Height="25px" runat="server"  Width="100%"  ReadOnly="true">
                                        <InvalidStyle BackColor="LightPink" />
                                    </dx:ASPxTextBox>
                                </div>
                                
                                <div class="col-md-2">
                                    <label for="txtCusName2" id="Label6" class="auto-style1">Customer Name 2</label>

                                </div>
                                <div class="col-md-4">
                                    <dx:ASPxTextBox ID="txtCusName2" BackColor="#F5F5F5" Height="25px" runat="server"  Width="100%"  ReadOnly="true">
                                        <InvalidStyle BackColor="LightPink" />
                                    </dx:ASPxTextBox>
                                </div>
                                

                                      </div>
                                </div>

                           <div class="row">
                                <div class="col-md-12">

                                <div class="col-md-2">
                                  
                                    <label for="txtCustAdd" id="Label7" class="auto-style1">Customer Address</label></div>
                                <div class="col-md-4">
                                      <dx:ASPxMemo ID="txtCustAdd" BackColor="#F5F5F5" Height="25px" runat="server"  Width="100%"  ReadOnly="true">

                                      </dx:ASPxMemo>
                           </div>
                                     <div class="col-md-2">
                                    <label for="txtProduct" id="Label8" class="auto-style1">Product</label>

                                </div>
                                <div class="col-md-4">
                                    <dx:ASPxMemo ID="txtProduct" BackColor="#F5F5F5" Height="25px" runat="server"  Width="100%"  ReadOnly="true">
                                    </dx:ASPxMemo>
                                </div>
                                </div>
                                
                            </div>
                            <div class="row">
                                   <div class="col-md-12">

                                <div class="col-md-2">
                                    <label for="txtpwRetype" id="Label3" class="auto-style1">Executive Name</label></div>
                                <div class="col-md-4">
                                    
                                     <dx:ASPxComboBox ID="txtOwner" BackColor="#F5F5F5" Height="25px" required="" Width="100%" runat="server"  DropDownStyle="DropDownList" DataSourceID="SqlDsActivity"
                                                    ValueField="ExecutiveId" TextField="Type" ValueType="System.String" TextFormatString="{0}"  NullText=" << Select Lead Assigning Executive >> " MaxLength="50">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="Name" Width="100px" />
                                                    </Columns>
                                                   <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right">
                                          <RequiredField IsRequired="true" ErrorText="Executive Name is required" />
                                          </ValidationSettings>
                                                    <InvalidStyle BackColor="LightPink"/>
                                                </dx:ASPxComboBox>

                                </div>

                                <div class="col-md-2">
                                    <label for="txtpwRetype" id="Label4" class="auto-style1">Status</label></div>
                                <div class="col-md-4">
                          <dx:ASPxComboBox ID="cbStatus" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" ValueType="System.String" TextFormatString="{0}" NullText="  << Select Status >> " ReadOnly="true">
                              <Items>
                                   <dx:ListEditItem Text="Assigned"  Value="2" ImageUrl="~/Images/Assign.png" />
                              </Items>
                              <ItemImage Height="15px" IconID="actions_apply_16x16">
                              </ItemImage>
                          </dx:ASPxComboBox>
                                </div>
                                       </div>
                                </div>
                                

                            

                             <div class="col-md-12">
                               <div class="box-footer">
                         <div class="pull-right" style="margin-left: 3px">
                               <dx:ASPxButton ID="btnClear" Width="80px" Height="20px" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" CausesValidation="False" Text="Cancel" OnClick="btnClear_Click">
                               </dx:ASPxButton> 
                          </div>
                          <div class="pull-right" style="margin-left: 3px">
                                <dx:ASPxButton ID="btnAdd" runat="server"   CssClass="btn btn-info"  Paddings-Padding="3px" Width="80px" Height="20px" Text="Save" OnClick="btnAdd_Click">
                                </dx:ASPxButton>
                          </div>
                                
                                   </div>  
                     </div>

                             <div class="col-md-12">

                                     <dx:ASPxGridView ID="gvAssignOwner" runat="server" AutoGenerateColumns="False" Font-Size ="Small" DataSourceID="dsAssignOwner" CssClass="col-md-12"
                                        ClientIDMode="AutoID" EnableTheming="True" KeyFieldName="Id" Theme="MetropolisBlue" Width="100%" OnHtmlDataCellPrepared="gvAssignOwner_HtmlDataCellPrepared" OnHtmlRowPrepared="gvAssignOwner_HtmlRowPrepared">
                                        <SettingsPager PageSize="50">
                                        </SettingsPager>
                                         <SettingsSearchPanel Visible="true" HighlightResults="true" />
                                         <SettingsBehavior AllowFocusedRow="True" />
                                        <Columns>

                                            <dx:GridViewDataTextColumn FieldName="Id" Caption="Id" VisibleIndex="1"   Visible="false">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="LeadName" Caption="Lead No" VisibleIndex="2" Width="80px">
                                                 <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                              <dx:GridViewDataTextColumn FieldName="ContactNo" Caption="Customer No" VisibleIndex="4" Width="100px">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="ContactNo2" Caption="Customer No" VisibleIndex="3" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="SecondName" Caption="Customer No" VisibleIndex="3" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CustomerId" Caption="Customer No" VisibleIndex="3" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="LeadOwnerId" Caption="Customer No" VisibleIndex="3" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer Name" VisibleIndex="3" Width="250px">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Address" Caption="Customer Address" VisibleIndex="5" Width="350px" >
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Name" Caption="Executive Name" VisibleIndex="6" Width="200px" >
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="ProductList" Caption="Executive Name" VisibleIndex="6" Visible="false" Width="200px" >
                                            </dx:GridViewDataTextColumn>
                                           <dx:GridViewDataTextColumn FieldName="LeadStatus" Caption="Status" VisibleIndex="8" Width="80px" >
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataCheckColumn FieldName="IsMessageSend" Caption="Quotation" VisibleIndex="7" Width="100px">
                                                <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataTextColumn Caption="Select" VisibleIndex="1" Width="70px">
                                                <CellStyle HorizontalAlign="Center" />
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="lkSelect" runat="server" OnInit="lkSelect_Init" OnClick="lkSelect_ClickEx">Select</asp:LinkButton>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                               <CellStyle HorizontalAlign="Center"/>
                                            </dx:GridViewDataTextColumn>

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

                           <div class="col-md-12">
                                <div class="box-footer">

                                         <div class="pull-right" style="margin-left: 3px">
                                             <%--<dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Export to Excel">
                                                  </dx:ASPxButton>--%>
                                        </div>
                           </div>

                            </div>

                       <dx:ASPxGridViewExporter ID="exportGrid2" GridViewID="gvAssignOwner" runat="server">
        </dx:ASPxGridViewExporter>

                   
  
                   
                            
                            </div>
                        </div>
            </section>
     <asp:HiddenField ID="hfAssignLeadId" runat="server" />

       <div class="modal fade bs-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel">Search Customer Leads</h4>

                </div>
                <div class="modal-body">

                    <dx:ASPxGridView ID="gvLeadSearch"   runat ="server" AutoGenerateColumns="False" ClientIDMode="AutoID" EnableTheming="True" KeyFieldName="CustomerId" Theme="MetropolisBlue" Width="880px">
                        <SettingsPager PageSize="10">
                        </SettingsPager>
                       
                        <SettingsSearchPanel Visible="true" HighlightResults="true" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="LeadNo" Caption="Lead No" VisibleIndex="1" Width="100">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="LeadSources" Caption="Lead Sources" VisibleIndex="2" Width="100">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer Name" VisibleIndex="3" Width="150">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="SecondName" Caption="Customer Name 2" VisibleIndex="4" Width="150">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ContactNo" Caption="Contact No 1" VisibleIndex="5" Width="100">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ContactNo2" Caption="Contact No 2" VisibleIndex="6" Width="100">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                               <dx:GridViewDataTextColumn FieldName="ItemName" Caption="Item Name" Visible ="false"  VisibleIndex="7" Width="100">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Address" Caption="Contact Address" Visible ="false" VisibleIndex="7" Width="100">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CustomerId" Caption="CustomerId" VisibleIndex="8" Width="100" Visible ="false">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="LeadId" Caption="LeadId" VisibleIndex="9" Width="100" Visible ="false">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Select" VisibleIndex="0" Width="80" >
                                <CellStyle HorizontalAlign="Center" />
                                <DataItemTemplate>
                                    <asp:LinkButton ID="lkSelect" runat="server" OnClick="lkSelect_Click">Select</asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                         

                        </Columns>
                            <Styles>
                                            <Header BackColor="WindowFrame" Font-Bold="true" HorizontalAlign="Center">
                                            </Header>
                                            <AlternatingRow BackColor="#F5F5F5">
                                            </AlternatingRow>
                                         </Styles>
                    </dx:ASPxGridView>

                </div>
                <div class="modal-footer">


                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <%--  <button type="button" class="btn btn-primary">Send message</button>--%>
                </div>
            </div>
        </div>
    </div>

            <asp:HiddenField ID="hfCustomerId" runat="server" />
            <asp:HiddenField ID="hfAssignId" runat="server" />
                <asp:SqlDataSource ID="dsAssignOwner" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                           SelectCommand="CRM_GetLeadAssignDetail" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter Name="LocationId" SessionField="LocationId" Type="Int32" />
                            </SelectParameters>
                           </asp:SqlDataSource> 

           <asp:SqlDataSource ID="SqlDsActivity" runat="server"
           ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
           SelectCommand="SELECT [ExecutiveId], [EPFNo], [Name]+'/'+[LocationName] as Name FROM [CRM_ExecutiveDetails] INNER JOIN
                          CRM_Location ON CRM_ExecutiveDetails.LocationId = CRM_Location.LocationId  WHERE Active= '1' AND CRM_ExecutiveDetails.LocationId=@LocationId ">
                 <SelectParameters>
                                <asp:SessionParameter Name="LocationId" SessionField="LocationId" Type="Int32" />
                 </SelectParameters>
           </asp:SqlDataSource>
    </asp:Content>