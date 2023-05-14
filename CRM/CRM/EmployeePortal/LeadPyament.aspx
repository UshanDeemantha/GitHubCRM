<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeadPyament.aspx.cs" Inherits="HRM.EmployeePortal.LeadPyament" MasterPageFile="~/Portal.Master" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            Width: 100%;
            height: 30px;
            font-family: Verdana;
            text-align: left;
        }
       .dxtcFixed {
            max-width: 550px;
        }
        .dxtcFixed .dxtmImage {
            width: 100%;
            max-width: 600px;
            max-height: 600px;
        }
    </style>
        <script>
            function onValidation(s, e) {

                e.isValid = true;
                //if (s.GetValue().trim().length == 0) {


                //}
            }
    </script>
    <script>
        function show() {
            $('#exampleModal').modal('toggle');
        }
        function close() {
            document.getElementById('exampleModal').className = 'hiddendiv';
        }
    </script>

<script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js?ver=1.3.2'></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("input").not($(":button")).keypress(function (evt) {
            if (evt.keyCode == 13) {
                iname = $(this).val();
                if (iname !== 'Search') {
                    var fields = $(this).parents('form:eq(0),body').find('button,input,textarea,select');
                    var index = fields.index(this);
                    if (index > -1 && (index + 1) < fields.length) {
                        fields.eq(index + 1).focus();
                    }
                    return false;
                }
            }
        });
    });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">

        <h1>Customer Payments</h1>
            <ol class="breadcrumb">
                    <li>
                        <i class="fa fa-briefcase"></i>
                        <asp:LinkButton ID="lkViewPayment" runat="server" OnClick="lkViewPayment_Click">&nbsp;View Payment Details</asp:LinkButton>

                    </li>
                    <%--   <li><a href="#">Forms</a></li>--%>
                </ol>

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
                            <div class="panel-heading">Search Details</div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-2">
                                                    <label for="txtContactNo" id="Label17" style="text-align: center" class="auto-style1">Customer No</label>
                                                </div>

                                                <div class="col-md-2">
                                                    <dx:ASPxTextBox ID="txtContactNo" ClientSideEvents-Validation="onValidation" BackColor="#F5F5F5" Height="25px" runat="server" Width="100px" HorizontalAlign="Center">
                                                        <MaskSettings Mask="0000000000" />
                                                    </dx:ASPxTextBox>
                                                </div>
                                         <div class="col-md-2">
                                            <label for="txtQuotationNo" id="Label1" style="text-align: center" class="auto-style1">Quotation No</label>
                                         </div>
                                        <div class="col-md-2">
                                            <dx:ASPxTextBox ID="txtQuotationNo" BackColor="#F5F5F5" required="" Height="25px" runat="server" Width="100%" MaxLength="100" HorizontalAlign="Center">
                                            </dx:ASPxTextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <label for="txtLeadName" id="lblUserName" style="text-align: center" class="auto-style1">Lead No</label>

                                        </div>
                                        <div class="col-md-2">
                                            <dx:ASPxTextBox ID="txtLeadName" BackColor="#F5F5F5" required="" Height="25px" runat="server" Width="100%" HorizontalAlign="Center">
                                            </dx:ASPxTextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box-footer">
                                            <div class="pull-right" style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnClear" Width="100px" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" CausesValidation="False" Text="Cancel" OnClick="btnClear_Click">
                                                </dx:ASPxButton>
                                            </div>


                                            <div class="pull-right" style="margin-left: 25px">
                                                <dx:ASPxButton ID="btnSearch" runat="server" CssClass="btn btn-info" Paddings-Padding="1px" Width="100px" Text="Search" OnClick="btnSearch_Click">
                                                    <Paddings Padding="1px" />
                                                </dx:ASPxButton>
                                            </div>
                                            <div>
                                            <div class="pull-right" style="margin-left: 3px">
                                            <asp:Label ID="lblResult" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>

                                            </div>

                                        </div>
                                            <div>
                                            <div class="pull-right" style="margin-left: 3px">
                                            <asp:Label ID="lblstatus" runat="server" Text="Last Lead Payment Status   : " Visible="false" Font-Bold="true"></asp:Label>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box box-default">
                            <div class="panel-heading">Lead Details</div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-2">
                                            <label for="txtCustomerName" id="Label2" class="auto-style1">Customer Name</label>

                                        </div>
                                        <div class="col-md-4">
                                            <dx:ASPxTextBox ID="txtCustomerName" BackColor="#F5F5F5" required="" Height="25px" runat="server" Width="100%" ReadOnly="true">
                                            </dx:ASPxTextBox>
                                        </div>

                                        <div class="col-md-2">
                                            <label for="txtSalesName" id="Label3" class="auto-style1">Executive Name</label>

                                        </div>
                                        <div class="col-md-4">
                                            <dx:ASPxTextBox ID="txtSalesName" BackColor="#F5F5F5" required="" Height="25px" runat="server" Width="100%" ReadOnly="true">
                                            </dx:ASPxTextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                           <div class="col-md-2">
                                            <label for="txtProductName" id="Label14" class="auto-style1">Product Name</label>

                                        </div>
                                        <div class="col-md-4">
                                            <dx:ASPxMemo ID="txtProductName" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%" ReadOnly="true"></dx:ASPxMemo>
                                        </div>
                                        
                                        <div class="col-md-2">
                                            <label for="txtReceiptNo" id="Label4" class="auto-style1">Receipt No</label>

                                        </div>
                                        <div class="col-md-2">
                                            <dx:ASPxTextBox ID="txtReceiptNo" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%">
                                            </dx:ASPxTextBox>
                                        </div>
                                       
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-2">
                                            <label for="txtDescription" id="Label6" class="auto-style1">Payment Type</label>

                                        </div>
                                        <div class="col-md-2">
                                            <dx:ASPxComboBox ID="dxcbRemarks" Height="25px" BackColor="#F5F5F5" Width="100%" runat="server" DropDownStyle="DropDownList"
                                                ValueType="System.String" TextFormatString="{0}" MaxLength="50" NullText="<<Payment Type>>">
                                           <Items>
                                                    <dx:ListEditItem Text="Advance Payment" Value="1"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="Second Payment" Value="2"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="Third Payment" Value="3"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="Balance Payment" Value="4"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="Full Payment" Value="5"></dx:ListEditItem>
                                                </Items>

                                            </dx:ASPxComboBox>
                                        </div>
                                         <div class="col-md-2">
                                             </div>
                                         <div class="col-md-2">
                                            <label for="txtDescription" id="Label5" class="auto-style1">Description</label>

                                        </div>
                                        <div class="col-md-4">
                                            <dx:ASPxMemo ID="xMDescription" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%">
                                            </dx:ASPxMemo>
                                        </div>
                                    </div>
                                </div>
                                  <div class="row">
                                      </div>
                                <div class="row">
                                    <div class="col-md-12">

                                        <div class="col-md-2">
                                        </div>
                                         <dx:ASPxPageControl ID="carTabPage"  Width="100%" runat="server" ActiveTabIndex="0" CssClass="dxtcFixed"  EnableHierarchyRecreation="True" AutoPostBack="true" OnTabClick="carTabPage_TabClick" Theme="Metropolis" >
        <TabPages>
            <dx:TabPage Text="Cash">
                <ContentCollection>
                    <dx:ContentControl ID="CashTab" runat="server">
                      <div class="row">
                     <div class="col-md-12">
                                                     
                                                        <div class="col-md-3">
                                                            <label for="txtCashAmount" id="Label13" class="auto-style1">Amount (LKR)</label>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <dx:ASPxTextBox ID="txtCashAmount"  BackColor="#F5F5F5" Height="25px" runat="server" Width="100px">
                                                                <MaskSettings Mask="&lt;0..9999999999g&gt;.&lt;00..99&gt;" />
                                                            </dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                        </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Direct Deposit">
                <ContentCollection>
                    <dx:ContentControl ID="DirectTab" runat="server">
                 
                        
                            <div class="row">
                               <div class="col-md-12">
                                     <div class="col-md-3">
                                               <label for="txtDirectAmount" id="Label7" class="auto-style1">Amount (LKR)</label>
                                     </div>
                                     <div class="col-md-3">
                                                <dx:ASPxTextBox ID="txtDirectAmount" BackColor="#F5F5F5" Height="25px" runat="server" Width="100px">
                                                    <MaskSettings Mask="&lt;0..9999999999g&gt;.&lt;00..99&gt;" />
                                                </dx:ASPxTextBox>
                                     </div>
                                     <div class="col-md-3">
                                               <label for="txtDirectBank" id="Label16" class="auto-style1">Bank</label>
                                     </div>
                                     <div class="col-md-3">
                                                <dx:ASPxTextBox ID="txtDirectBank" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                     </div>
                                </div>
                          </div>

                        <div class="row">
                         <div class="col-md-12">
                           <div class="col-md-3">
                                  <label for="dxDepositDate" id="Label15" class="auto-style1">Deposit Date</label>
                                     </div>
                                  <div class="col-md-3">
                                         <dx:ASPxTextBox ID="dxDepositDate" BackColor="#F5F5F5" Height="25px" runat="server" Width="100px">
                                              <MaskSettings Mask="dd/MM/yyyy" />
                                                </dx:ASPxTextBox>
                               
                            </div>
                            </div>
                            </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Cheque">
                <ContentCollection>
                    <dx:ContentControl ID="ChequeTab" runat="server">
                      <div class="row">
                              <div class="col-md-12">
                                      <div class="col-md-3">
                                                  <label for="txtChequeAmount" id="Label8" class="auto-style1">Amount (LKR)</label>
                                       </div>
                                       <div class="col-md-3">
                                                  <dx:ASPxTextBox ID="txtChequeAmount" BackColor="#F5F5F5" Height="25px" runat="server" Width="100px">
                                                      <MaskSettings Mask="&lt;0..9999999999g&gt;.&lt;00..99&gt;" />
                                                   </dx:ASPxTextBox>
                                        </div>
                                        <div class="col-md-3">
                                                    <label for="txtBank" id="Label10" class="auto-style1">Bank</label>
                                        </div>
                                        <div class="col-md-3">
                                                    <dx:ASPxTextBox ID="txtBank" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%">
                                                    </dx:ASPxTextBox>
                                         </div>
                                  </div>
                         </div>
                         <div class="row">
                                   <div class="col-md-12">

                                        <div class="col-md-3">
                                                     <label for="txtChequeNo" id="Label11" class="auto-style1">Cheque No</label>
                                         </div>
                                         <div class="col-md-3">
                                                      <dx:ASPxTextBox ID="txtChequeNo" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%">
                                                       </dx:ASPxTextBox>
                                          </div>
                                          <div class="col-md-3">
                                                       <label for="txtBranch" id="Label12" class="auto-style1">Branch</label>
                                          </div>
                                          <div class="col-md-3">
                                                       <dx:ASPxTextBox ID="txtBranch" BackColor="#F5F5F5" Height="25px" runat="server" Width="100%">
                                                       </dx:ASPxTextBox>
                                           </div>

                                     </div>
                           </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
               <dx:TabPage Text="Credit Card">
                <ContentCollection>
                    <dx:ContentControl ID="CreditTab" runat="server">
                       <div class="row">
                                                    <div class="col-md-12">
                                                     
                                                        <div class="col-md-3">
                                                            <label for="txtCreditAmount" id="Label9" class="auto-style1">Amount (LKR)</label>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <dx:ASPxTextBox ID="txtCreditAmount" BackColor="#F5F5F5" Height="25px" runat="server" Width="100px">
                                                                <MaskSettings Mask="&lt;0..9999999999g&gt;.&lt;00..99&gt;" />
                                                            </dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                           
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
                                        
                                          <div class="row">
                                            <div class="col-md-12">

                                                <div class="box-footer">
                                                    <div class="pull-right" style="margin-left: 3px">
                                                        <dx:ASPxButton ID="btnClear1" Width="80px" Height="20px" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" Text="Cancel" OnClick="btnClear1_Click">
                                                        </dx:ASPxButton>
                                                    </div>
                                                    <div class="pull-right" style="margin-left: 25px">
                                                        <dx:ASPxButton ID="btnSave" runat="server" CssClass="btn btn-info" Paddings-Padding="3px" Width="80px" Height="20px" Text="Save" OnClick="btnSave_Click">
                                                        </dx:ASPxButton>
                                                    </div>
                                                     <div class="pull-right" style="margin-left: 3px">
                                                        <asp:Label ID="Label18" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
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

</asp:Content>
