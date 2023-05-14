<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewJobHistory.aspx.cs" Inherits="HRM.EmployeePortal.ViewJobHistory" MasterPageFile="~/Portal.Master" %>


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
        <h1>Job History
           <%-- <small>Advanced form element</small>--%>
        </h1>
      
    </section>
    <section class="content">
     
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="box box-default">
                        <div class="box-body">
                            <div class="row">
                                  <div class="col-md-2">
                                     <label for="dxFromDate" id="Label1" style="text-align:center" class="auto-style1">From Date</label>
                                     </div>
                                  <div class="col-md-2">
                               <dx:ASPxDateEdit ID="dxFromDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                               </dx:ASPxDateEdit>
                                      </div>
                                  <div class="col-md-2">
                                  <label for="dxcbLeadSource" id="Label3" style="text-align:center" class="auto-style1">To Date</label>
                                     </div>
                                  <div class="col-md-2">
                               <dx:ASPxDateEdit ID="dxToDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                               </dx:ASPxDateEdit>
                            </div>
                                                  <div class="col-md-2">
                                        <label for="txtpwRetype" id="Label4" class="auto-style1" style="text-align:center">Status</label>

                                    </div>
                                    <div class="col-md-2">
                                        <dx:ASPxComboBox ID="cbStatus" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" ValueType="System.String" TextFormatString="{0}"  NullText=" << Select Status >> ">
                                            <Items>
                                                <dx:ListEditItem Text="Select All" Value="0" ImageUrl="~/Images/All.png" />
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
                                      
                                 <div class="col-md-12">
                                      <div class="box-footer">
                                           <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnClear" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" CausesValidation="False" Text="Cancel" OnClick="btnClear_Click">
                                                </dx:ASPxButton>
                                            </div>
                                        <div class="pull-right" style="margin-left: 3px">
                                            <dx:ASPxButton ID="btnSearch" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" CausesValidation="False" Text="Search" OnClick="btnSearch_Click">
                                            </dx:ASPxButton>
                                        </div>


                                          </div>
                                    </div>
                            </div>
                            <div class="row">

                                <div class="col-md-12">

                                    <dx:ASPxGridView ID="gvAssignJobHistory" runat="server" AutoGenerateColumns="False" Font-Size="Small"  CssClass="col-md-12" OnHtmlDataCellPrepared="gvAssignJobHistory_HtmlDataCellPrepared"
                                        ClientIDMode="AutoID" EnableTheming="True" KeyFieldName="LeadName" Theme="MetropolisBlue" Width="100%" OnHtmlRowPrepared="gvAssignJobHistory_HtmlRowPrepared" >
                                        <SettingsPager PageSize="50">
                                        </SettingsPager>
                                        <Settings HorizontalScrollBarMode="Auto" />
                                        <SettingsBehavior AllowFocusedRow="true" />
                                        <Columns>

                                            <dx:GridViewDataTextColumn FieldName="Id" Caption="Id" VisibleIndex="1" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LeadName" Caption="Lead No" VisibleIndex="1" Width="80px">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LeadSources"  Caption="Lead Source" VisibleIndex="2" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="4" Width="250px" >
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="ContactNo" Caption="Customer No" VisibleIndex="5" Width="90px">
                                                 <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Address" Caption="Customer Address" VisibleIndex="6" Width="350px">
                                               
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CreatedDate" Caption="Job Date" VisibleIndex="3" Width="80px">
                                                <CellStyle HorizontalAlign="Center" />
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesTextEdit>
                                                <Settings GroupInterval="Value" />
                                            </dx:GridViewDataTextColumn>
                                               <dx:GridViewDataTextColumn FieldName="Activity" Caption="Job Activity" VisibleIndex="13" Width="150px">
                                                    <CellStyle HorizontalAlign="Center" />
                                               </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DueDate" Caption="Due Date" VisibleIndex="7" Width="80px">
                                                  <CellStyle HorizontalAlign="Center" />
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesTextEdit>
                                                <Settings GroupInterval="Value" />
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="Subject" Caption="Subject" VisibleIndex="8" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LeadOwner" Caption="Executive" VisibleIndex="9" Width="200px">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="ExeContact" Caption="Executive No" VisibleIndex="10" Width="90px">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn> 
                                             <dx:GridViewDataTextColumn FieldName="Comment" Caption="Comment" VisibleIndex="11" Width="200px">
                                            </dx:GridViewDataTextColumn>
                                              <dx:GridViewDataTextColumn FieldName="LeadStatus" Caption="Status" VisibleIndex="2" Width="80px">
                                                 <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="UpdateDate" Caption="Modify Date" VisibleIndex="12" Width="90px">
                                                <CellStyle HorizontalAlign="Center" />
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesTextEdit>
                                                <Settings GroupInterval="Value" />
                                            </dx:GridViewDataTextColumn>
                                                  <dx:GridViewDataTextColumn FieldName="CreatedUser" Caption="User" VisibleIndex="14" Width="80px">
                                            </dx:GridViewDataTextColumn>
                                       
                                         
                                  
                                        </Columns>
                                       
                                          <SettingsText SearchPanelEditorNullText=" " />
                                       
                                          <SettingsSearchPanel Visible="true"    />
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

                                <div class="col-md-12">
                                <div class="box-footer">

                                         <div class="pull-right" style="margin-left: 3px">
                                          <%--   <dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Export to Excel">
                                                  </dx:ASPxButton>--%>
                                        </div>
                           </div>

                            </div>

                       <dx:ASPxGridViewExporter ID="exportGrid3" GridViewID="gvAssignJobHistory" runat="server">
                        </dx:ASPxGridViewExporter>

                            </div>

                        </div>

                    </div>
                       
                </ContentTemplate>
            </asp:UpdatePanel>
      
    </section>
    <asp:HiddenField ID="hfAssignLeadId" runat="server" />

    </asp:Content>