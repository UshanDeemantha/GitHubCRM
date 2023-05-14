<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Performance.aspx.cs" Inherits="HRM.EmployeePortal.Performance" MasterPageFile="~/Portal.Master"%>

<%@ Register Assembly="DevExpress.Dashboard.v14.2.Web, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v14.2.Web, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style type="text/css">
        .auto-style1 {
             Width:100%;
            height: 30px;
            font-family:Verdana;
            text-align:left;
            
        }
hr.style14 { 
  border: 0; 
  height: 1px; 
  background-image: -webkit-linear-gradient(left, #f0f0f0, #8c8b8b, #f0f0f0);
  background-image: -moz-linear-gradient(left, #f0f0f0, #8c8b8b, #f0f0f0);
  background-image: -ms-linear-gradient(left, #f0f0f0, #8c8b8b, #f0f0f0);
  background-image: -o-linear-gradient(left, #f0f0f0, #8c8b8b, #f0f0f0); 
}
         </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <section class="content-header">
            <h1>Executive Details
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
                             
                          
                            <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" AppearanceNameSerializable="Nature Colors" CrosshairEnabled="True" DataSourceID="SqlDataSource1" Height="228px" PaletteBaseColorNumber="2" PaletteName="Civic" style="margin-left: 24px" Width="985px">
                                <diagramserializable>
                                    <cc1:XYDiagram>
                                        <axisx visibleinpanesserializable="-1">
                                        </axisx>
                                        <axisy visibleinpanesserializable="-1">
                                        </axisy>
                                        <margins bottom="10" left="10" right="10" top="10" />
                                    </cc1:XYDiagram>
                                </diagramserializable>
                                <seriesserializable>
                                    <cc1:Series ArgumentDataMember="CreatedDate" ArgumentScaleType="DateTime" Name="Won" ValueDataMembersSerializable="Status">
                                        <datafilters>
                                            <cc1:DataFilter ColumnName="Status" DataType="System.Int32" InvariantValueSerializable="6" />
                                        </datafilters>
                                    </cc1:Series>
                                    <cc1:Series ArgumentDataMember="CreatedDate" ArgumentScaleType="DateTime" Name="Lost" ValueDataMembersSerializable="Status">
                                        <datafilters>
                                            <cc1:DataFilter ColumnName="Status" DataType="System.Int32" InvariantValueSerializable="7" />
                                        </datafilters>
                                    </cc1:Series>
                                    <cc1:Series ArgumentDataMember="CreatedDate" ArgumentScaleType="DateTime" Name="Assigned" ValueDataMembersSerializable="Status">
                                        <datafilters>
                                            <cc1:DataFilter InvariantValueSerializable="2" />
                                        </datafilters>
                                    </cc1:Series>
                                </seriesserializable>
                            </dxchartsui:WebChartControl>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [LeadNo], [Status], [CreatedDate] FROM [CRM_LeadHeader]"></asp:SqlDataSource>
                             
                          
                        </div>

                    </div>
     
                    </div>
                                              </ContentTemplate>
                 </asp:UpdatePanel>
              </div>   
            </section>
     <asp:HiddenField ID="hfExecutiveId" runat="server" />
                      <%--     <asp:SqlDataSource ID="dsExecutive" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                           SelectCommand="CRM_GetExecutiveDetails" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="ExecutiveId" Type="Int32" />
                            </SelectParameters>
                           </asp:SqlDataSource> --%>

    </asp:Content>