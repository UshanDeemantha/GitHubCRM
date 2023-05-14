<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssigningActivity.aspx.cs"  Inherits="HRM.EmployeePortal.AssigningActivity" MasterPageFile="~/Portal.Master" %>

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
            <h1>Assign Job Activities
           <%-- <small>Advanced form element</small>--%>
            </h1>
            <ol class="breadcrumb">
               <%-- <li><a href="Default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>--%>
                 <li> 
                        <asp:LinkButton ID="lkSearchLeads" runat="server" OnClick="lkSearchLeads_Click" Visible="false">Search Customer</asp:LinkButton>

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
                                <label for="txtLeadName" id="lblUserName" class="auto-style1">Lead No</label>
                            </div>
                            <div class="col-md-2">
                                <dx:ASPxTextBox ID="txtLeadName" BackColor="#F5F5F5" required="" Height="25px" runat="server" Width="100%" ReadOnly="true">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right">
                                        <RequiredField IsRequired="true" ErrorText="Lead No is required" />
                                    </ValidationSettings>
                                    <InvalidStyle BackColor="LightPink" />
                                </dx:ASPxTextBox>
                            </div>
                                    <div class="col-md-1">
                                   
                                <asp:Button ID="Button1" runat="server" class="btn btn-info" Enabled="false" Text="Search" Height="35px" OnClick="Button1_Click"  />
                                

                            </div>

                       </div>
                       
                            <div class="col-md-12">
                            <div class="col-md-2">
                                <label for="txtpw" id="Label1" class="auto-style1">Contact No 1</label>
                            </div>
                            <div class="col-md-2">
                                <dx:ASPxTextBox ID="txtPhone" BackColor="#F5F5F5" required=""  Height="25px" runat="server" Width="100%" ReadOnly="true">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right">
                                        <RequiredField IsRequired="true" ErrorText="Contact No is required" />
                                    </ValidationSettings>
                                    <InvalidStyle BackColor="LightPink" />
                                </dx:ASPxTextBox>
                            </div>

                        </div>

                           <div class="col-md-12">

                            <div class="col-md-2">
                                <label for="txtpw" id="Label7" class="auto-style1">Contact No 2</label>
                            </div>
                            <div class="col-md-2">
                                <dx:ASPxTextBox ID="txtPhone2" BackColor="#F5F5F5" required="" Height="25px" runat="server" Width="100%" ReadOnly="true">
                                    
                                    <InvalidStyle BackColor="LightPink" />
                                </dx:ASPxTextBox>
                            </div>

                                <div class="col-md-2">
                                 <dx:ASPxCheckBox ID="cbQuotation" runat="server" Text="Quotation" ReadOnly="true" Checked="false"></dx:ASPxCheckBox>
                                 </div>

                        </div>
                      
                        <div class="col-md-12">
                            <div class="col-md-2">
                                <label for="dxcomActivity" id="Label5" class="auto-style1">Job Activity</label>
                            </div>
                            <div class="col-md-4">
                               <dx:ASPxComboBox ID="dxcomActivity" BackColor="#F5F5F5" Height="25px" required="" Width="100%" runat="server"  DropDownStyle="DropDownList" AutoPostBack="true" DataSourceID="SqlDsActivity" OnSelectedIndexChanged="dxcomActivity_SelectedIndexChanged"
                                                    ValueField="Id" TextField="Type" ValueType="System.String" TextFormatString="{0}"  NullText=" << Select Job Activity >> " MaxLength="50">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="Type" Width="100px" />
                                                    </Columns>
                                                  
                                                    <InvalidStyle BackColor="LightPink"/>
                                                </dx:ASPxComboBox>
                            </div>



                        </div>
                             <div class="col-md-12">

                            <div class="col-md-2">
                                <label for="txtSubject" id="Label2" class="auto-style1">Description</label>
                            </div>
                            <div class="col-md-4">
                                <dx:ASPxTextBox ID="txtSubject" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" ClientInstanceName="txtPasswordreEnter" MaxLength="100">
                                    <InvalidStyle BackColor="LightPink" />
                                </dx:ASPxTextBox>
                            </div>




                        </div>
                         <div class="col-md-12">
                            <div class="col-md-2">
                                <label for="txtActOwner" id="Label6" class="auto-style1">Due Date</label>
                            </div>
                            <div class="col-md-2">
                               <dx:ASPxDateEdit ID="dtStartDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="yyyy-MM-dd" EditFormatString="yyyy-MM-dd">
                               </dx:ASPxDateEdit>
                            </div>
                            </div>
                       <div class="col-md-12">
                            <div class="col-md-2">
                                <label for="txtActOwner" id="Label3" class="auto-style1">Executive Name</label>
                            </div>
                            <div class="col-md-4">
                             <dx:ASPxComboBox ID="txtOwner" BackColor="#F5F5F5" Height="25px" required="" Width="100%" runat="server"  DropDownStyle="DropDownList" DataSourceID="SqlDsOwner"
                              ValueField="ExecutiveId" TextField="Type" ValueType="System.String" TextFormatString="{0}"  NullText=" << Select Job Assigning Executive >> " MaxLength="50" ReadOnly="true">
                               <Columns>
                                  <dx:ListBoxColumn FieldName="Name" Width="100px" />
                               </Columns>
                                           
                                      <InvalidStyle BackColor="LightPink"/>
                                </dx:ASPxComboBox>
                            </div>



                        </div>
                      <div class="col-md-12">

                            <div class="col-md-2">
                                <label for="cbStatus" id="Label4" class="auto-style1">Status</label>
                            </div>
                            <div class="col-md-2">
                                <dx:ASPxComboBox ID="cbStatus" runat="server" Height="25px" Width="100%" BackColor="#F5F5F5" ValueType="System.String" TextFormatString="{0}"  NullText=" << Select Status >> " ReadOnly="true">
                                    <Items>
                                   
                                        <dx:ListEditItem Text="Assigned" Value="2" ImageUrl="~/Images/Assign.png"/>
                                      
                                    </Items>
                                    <ItemImage Height="15px" IconID="actions_apply_16x16">
                                    </ItemImage>
                                </dx:ASPxComboBox>
                            </div>



                        </div>


                        <div class="col-md-12">
                               <div class="box-footer">
                         <div class="pull-right" style="margin-left: 3px">
                               <dx:ASPxButton ID="btnClear"  Width="80px" Height="20px" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" CausesValidation="False" Text="Clear" OnClick="btnClear_Click">
                               </dx:ASPxButton> 
                          </div>
                          <div class="pull-right" style="margin-left: 3px">
                                <dx:ASPxButton ID="btnAdd" runat="server"   CssClass="btn btn-info"  Paddings-Padding="3px"  Width="80px" Height="20px" Text="Add" OnClick="btnAdd_Click">
                                </dx:ASPxButton>
                          </div>
                          <div class="pull-right" style="margin-left: 3px">
                           <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>

                           </div>
                                
                                   </div>  
                     </div>

                            <div class="col-md-12">

                                       <dx:ASPxGridView ID="gvAssigningActivity" runat="server" AutoGenerateColumns="False" Font-Size ="Small"  
                                        ClientIDMode="AutoID" EnableTheming="True" Theme="MetropolisBlue" Width="100%" >
                                        <SettingsPager PageSize="10">
                                        </SettingsPager>
                                        
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="Id" Caption="id " VisibleIndex="0" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LeadNo" Caption="Lead No" VisibleIndex="1" Width="50px">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PhoneNo" Caption="Contact No 1" VisibleIndex="2" Visible="false">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="PhoneNo2" Caption="Contact No 2" VisibleIndex="3" Visible="false">
                                                 <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Subject" Caption="Description"  VisibleIndex="5">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Activity" Caption="Job Activity " VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                              <dx:GridViewDataTextColumn FieldName="ActivityId" Caption="Comment " VisibleIndex="3" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="ActivityOwner" Caption="Executive Name" VisibleIndex="6">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DueDate" Settings-GroupInterval="Value" Caption="Due Date" VisibleIndex="7" CellStyle-CssClass="col-md-2">
                                                <CellStyle HorizontalAlign="Center" />
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Status" Caption="Status" VisibleIndex="8">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn  VisibleIndex="9" Width="130px" >
                                                <CellStyle HorizontalAlign="Center" />
                                              <DataItemTemplate  >
                                                <dx:ASPxButton ID="btnEdit" runat="server" RenderMode="Link"
                                                    Width="55px" Height="25px" Text="Edit" AutoPostBack="false" ImagePosition="Right"  OnClick="btnEdit_Click">
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

                             
                                        <div class="col-md-12">
                                            <div class="box-footer">
                                                    <div class="pull-right" style="margin-left: 3px">
                                                        <dx:ASPxButton ID="btnClear1" Width="80px" Height="20px" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" Text="Cancel" OnClick="btnClear1_Click">
                                                        </dx:ASPxButton> 
                                                    </div>
                                                    <div class="pull-right" style="margin-left: 3px">
                                                        <dx:ASPxButton ID="btnSave" runat="server"   CssClass="btn btn-info"  Paddings-Padding="3px" Width="80px" Height="20px" Text="Save" OnClick="btnSave_Click">
                                                        </dx:ASPxButton>
                                                    </div>
                                            </div> 
                                        </div>
                                 




                        </div>

                  

   
                    </div>
                             <dx:ASPxPopupControl ID="confirmpopup" runat="server" HeaderText="Confirm Message" Height="100px" PopupHorizontalAlign="WindowCenter" Width="300px" PopupVerticalAlign="WindowCenter" >
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
                                                                <asp:Button ID="Button2" runat="server" Height="30px" Width="120px" Text="Yes" OnClick="btnDelete_Click1" CssClass="btn btn-block btn-success btn-large" />
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

              </div> 
            </section>
     <asp:HiddenField ID="hfUserTypeId" runat="server" />
           <asp:SqlDataSource ID="dsAssignActivity" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                           SelectCommand="CRM_AssignActivityType" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="EmployeeId" Type="Int64" />
                            </SelectParameters>
                           </asp:SqlDataSource> 
       <asp:SqlDataSource ID="SqlDsActivity" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                    SelectCommand="SELECT [Id], [Type], [Description], [Active] FROM [CRM_ActivityType] WHERE Active='1'"></asp:SqlDataSource>
       <div class="modal fade bs-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel">Search Customer Leads </h4>

                </div>
                <div class="modal-body">

                    <dx:ASPxGridView ID="gvLeadSearch"   runat ="server" AutoGenerateColumns="False" ClientIDMode="AutoID" EnableTheming="True" KeyFieldName="LeadNo" Theme="MetropolisBlue" Width="100%">
                        <SettingsPager PageSize="10">
                        </SettingsPager>
                       
                        <SettingsSearchPanel Visible="true" HighlightResults="true" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="LeadNo" Caption="Lead No" VisibleIndex="1" Width="50px">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ContactNo" Caption="Contact No 1" VisibleIndex="5">
                                <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="ContactNo2" Caption="Contact No 2" VisibleIndex="6">
                                 <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer Name" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="SecondName" Caption="Customer Name 2" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="IsMessageSend" Caption="Customer Name 2" VisibleIndex="4" Visible="false">
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="LeadSources" Caption="Lead Sources" VisibleIndex="2">
                                 <CellStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="LeadOwnerId" Caption="LeadSources" VisibleIndex="6" Width="100" Visible="false">
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="CustomerId" Caption="LeadSources" VisibleIndex="6" Width="100" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Select" VisibleIndex="0" Width="80" >
                                <CellStyle HorizontalAlign="Center" />
                                <DataItemTemplate>
                                    <asp:LinkButton ID="lkSelectSearch" runat="server" OnClick="lkSelectSearch_Click">Select</asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="LeadNo" FieldName="LeadNo" VisibleIndex="6" Width="20" Visible="False">
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
    <asp:SqlDataSource ID="SqlDsOwner" runat="server"
           ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [ExecutiveId], [EPFNo], [Name]+'/'+[LocationName] as Name FROM [CRM_ExecutiveDetails] INNER JOIN
                          CRM_Location ON CRM_ExecutiveDetails.LocationId = CRM_Location.LocationId  WHERE Active= '1' AND CRM_ExecutiveDetails.LocationId=@LocationId ">
                 <SelectParameters>
                                <asp:SessionParameter Name="LocationId" SessionField="LocationId" Type="Int32" />
                 </SelectParameters>
           </asp:SqlDataSource>
    </asp:Content>