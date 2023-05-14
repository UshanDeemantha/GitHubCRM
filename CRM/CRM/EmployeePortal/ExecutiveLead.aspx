<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExecutiveLead.aspx.cs" Inherits="HRM.EmployeePortal.ExecutiveLead"  MasterPageFile="~/Portal.Master" %>

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
        <h1>
           Executive Leads
        </h1>
      
    </section>
    <section class="content">
     
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="box box-default">
                        <div class="box-body">
                            <div class="row">
                                  <div class="col-md-3">
                                     <label for="dxFromDate" id="Label1" style="text-align:center" class="auto-style1">From Date</label>
                                     </div>
                                  <div class="col-md-3">
                               <dx:ASPxDateEdit ID="dxFromDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                               </dx:ASPxDateEdit>
                                      </div>
                                  <div class="col-md-3">
                                  <label for="dxcbLeadSource" id="Label3" style="text-align:center" class="auto-style1">To Date</label>
                                     </div>
                                  <div class="col-md-3">
                               <dx:ASPxDateEdit ID="dxToDate" runat="server" Height="25px" BackColor="#F5F5F5" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                               </dx:ASPxDateEdit>
                            </div>
                                 
                         </div>
                                 <div class="row">
                                      
                                 <div class="col-md-12">
                                      <div class="box-footer">
                                        <div class="pull-right" style="margin-left: 3px">
                                            <dx:ASPxButton ID="btnSearch" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" CausesValidation="False" Text="Search" OnClick="btnSearch_Click">
                                            </dx:ASPxButton>
                                        </div>


                                          </div>
                                    </div>
                            </div>
                            <div class="row">

                                <div class="col-md-12">


                                   <dx:ASPxGridView ID="gvExecutiveLead" runat="server" AutoGenerateColumns="False" Font-Size="Small" CssClass="col-md-12"
                                            ClientIDMode="AutoID" EnableTheming="True" KeyFieldName="LeadOwnerId" Theme="MetropolisBlue" Width="100%" >
                                  
                                            <SettingsPager PageSize="50">
                                            </SettingsPager>
                                            <SettingsSearchPanel Visible="true" HighlightResults="true" />
                                     <SettingsBehavior AllowFocusedRow="true" />
                                            <Columns>

                                                <dx:GridViewDataTextColumn FieldName="LeadOwnerId" Caption="LeadOwnerId" VisibleIndex="1" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn FieldName="EPFNo" Caption="Employee Code" VisibleIndex="2" Width="100px" >
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Executive Name" VisibleIndex="3" Width="250px" >
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn FieldName="LocationName" Caption="Location" VisibleIndex="5" Width="200px" >
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ContactNo" Caption="Executive No " VisibleIndex="4" Width="80px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="EConut" Caption="Number of Leads" VisibleIndex="6" Width="100px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn VisibleIndex="1" Width="80px">
                                                    <CellStyle HorizontalAlign="Center" />
                                                    <DataItemTemplate>
                                                        <dx:ASPxButton ID="btnviewLead" runat="server" RenderMode="Link"
                                                            Width="70px" Height="20px" Text="Assign" AutoPostBack="false" ImagePosition="Right" OnClick="btnviewLead_Click">
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

                          <div class="col-md-12">
                                <div class="box-footer">

                                         <div class="pull-right" style="margin-left: 3px">
                                             <%--<dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Export to Excel">
                                                  </dx:ASPxButton>--%>
                                        </div>
                           </div>

                            </div>


                            <dx:ASPxGridViewExporter ID="exportGrid4" GridViewID="gvExecutiveLead" runat="server">
                            </dx:ASPxGridViewExporter>


                            </div>

                        </div>

                    </div>
                       
                </ContentTemplate>
            </asp:UpdatePanel>
      
    </section>
    <asp:HiddenField ID="hfAssignLeadId" runat="server" />

    </asp:Content>
