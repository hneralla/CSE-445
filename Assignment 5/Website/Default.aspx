<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>DayPlanner</h1>
                <h3><font color="white">    A tool to help people plan their day!</font></h3>
                <h5><a runat="server" href="~/About"><font color="white">Service Directory</font></a></h5>
            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>DayPlanner allows you to:</h3>
    <ol class="round">
        <li class="one">
            <h5>Check the weather.</h5>
            Members can check weather conditions of a specific ZIP code. This service will allow members to plan their day accordingly. </li>
        <li class="two">
            <h5>Plan for shopping.</h5>
            Members can search for nearest stores using a store name and ZIP code.
        </li>
        <li class="three">
            <h5>Find the distance.</h5>
            Members can find the distance and travel duration between two locations.
        </li>
        <h4><a runat="server" href="~/Account/Verify">Register Today!</a></h4>
        <li>
            <p>
                &nbsp;</p>
            <h3> Staff Member? </h3>
        </li>
        <li>
            <h4><a runat="server" href="~/Account/Login">Staff Login</a></h4> 
            <h4><a runat="server" href="~/Protected/Staff">Staff Page</a></h4>
        </li>
    </ol>
    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
