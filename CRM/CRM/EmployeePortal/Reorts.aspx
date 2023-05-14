<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reorts.aspx.cs" Inherits="HRM.EmployeePortal.Reorts" MasterPageFile="~/Portal.Master" %>

<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

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
    <div>
         <section class="content-header">
            <h1>Lead Registration
           <%-- <small>Advanced form element</small>--%>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <%--   <li><a href="#">Forms</a></li>--%>
            </ol>
        </section>

         <section class="content">
          <div class='row'>
              <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" Theme="Office2010Blue" ReportTypeName="HRM.EmployeePortal.CustomerLead"  >
                    <SettingsParametersPanelCaption HorizontalAlign="Left" Position="Left" />
                <StylesViewer>
                    <Paddings Padding="40px"></Paddings>
                </StylesViewer>

                <StylesReportViewer>
                    <Paddings Padding="10px"></Paddings>
                </StylesReportViewer>
                <StylesParametersPanelParameterEditors>
                <CaptionCell Width="40px">
                </CaptionCell>
                </StylesParametersPanelParameterEditors> 

              </dx:ASPxDocumentViewer>
              </div>
             </section>

        </div>
    </asp:Content>