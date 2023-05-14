<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHistory.aspx.cs" Inherits="HRM.EmployeePortal.CustomerHistory"  MasterPageFile="~/Portal.Master"%>

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
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <section class="content-header">
            <h1>Customer History
           <%-- <small>Advanced form element</small>--%>
            </h1>
          
        </section>
            <section class="content">
                 <div class='row'>
           <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class='col-md-12'>
                   
                <div class="box box-default">

                    <div class="box-body">
                        <div class="row">
                                     

                            <div class="col-md-12">

                                     <dx:ASPxGridView ID="gvCusHis" runat="server" AutoGenerateColumns="False" Font-Size ="Small" DataSourceID="dsCusHis" CssClass="col-md-12" OnHtmlRowPrepared="gvCusHis_HtmlRowPrepared"
                                        ClientIDMode="AutoID" EnableTheming="True"  KeyFieldName="LeadNo" Theme="MetropolisBlue" Width="100%"   OnHtmlDataCellPrepared="Grid_HtmlDataCellPrepared"   >
                                        <SettingsPager PageSize="50">
                                        </SettingsPager>
                                       
                                        <SettingsBehavior AllowFocusedRow="true" />
                                        <SettingsSearchPanel Visible="true"  HighlightResults="true"  />
                                         <StylesFilterControl ></StylesFilterControl> 
                                        <Columns>

                                       
                                            <dx:GridViewDataTextColumn FieldName="LeadNo" Caption="Id" VisibleIndex="1" CellStyle-CssClass="col-md-5"  Visible="false">
                                                <CellStyle CssClass="col-md-5">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="LeadNo" Caption="Lead No" VisibleIndex="1" Width="80px">
                                                 <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn FieldName="CreatedDate" Settings-GroupInterval="Value" Caption="Lead Date" VisibleIndex="7" Width="100px">
                                                     <Settings GroupInterval="Value" />
                                                    <CellStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd">
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ProductList"  Caption ="Products List" VisibleIndex="4" Width="250px">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Quantity" Caption="Quantity" VisibleIndex="6" Width="50px" Visible="false">
                                                <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer Name" VisibleIndex="2" Width="250px" >
                                            </dx:GridViewDataTextColumn>
                                          <dx:GridViewDataTextColumn FieldName="ContactNo" Caption="Customer No" VisibleIndex="3" Width="80px">
                                              <CellStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="exeName" Caption="Executive Name" VisibleIndex="5" >
                                            </dx:GridViewDataTextColumn>
                                               <dx:GridViewDataTextColumn FieldName="LeadStatus" Caption="Status" VisibleIndex="8" Width="100px" >
                                                   <CellStyle HorizontalAlign="Center" />
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
                                      <%--       <dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Export to Excel">
                                                  </dx:ASPxButton>--%>
                                        </div>
                           </div>

                            </div>


                            <dx:ASPxGridViewExporter ID="exportGrid1" GridViewID="gvCusHis" runat="server">
                            </dx:ASPxGridViewExporter>

                     
                        </div>

                    </div>
     
                    </div>
                                              </ContentTemplate>
                 </asp:UpdatePanel>
              </div>   
            </section>
     <asp:HiddenField ID="hfitemId" runat="server" />
            <asp:SqlDataSource ID="dsCusHis" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                           SelectCommand="CRM_GetCustomerHistory" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="ProductId" Type="Int32" />
                                 <asp:SessionParameter Name="LocationId" SessionField="LocationId" Type="Int32" />
                            </SelectParameters>
                           </asp:SqlDataSource> 

    </asp:Content>