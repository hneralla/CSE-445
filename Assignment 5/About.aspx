<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1></h1>
        <h2>Service Directory</h2>
    </hgroup>
    <table class="centerTable" align="left">
    
  <tr>
    <th class="tg-yw4l" colspan="5" bgcolor="CornflowerBlue">This project is developed by: Harith Neralla</th>
  </tr>
  <tr>
    <td class="tg-yw4l" bgcolor="CornflowerBlue">Provider Name</td>
    <td class="tg-yw4l" bgcolor="CornflowerBlue">Type</td>
    <td class="tg-yw4l" bgcolor="CornflowerBlue">Service name, with<br>input and output types</td>
    <td class="tg-yw4l" bgcolor="CornflowerBlue">Service Description</td>
  </tr>
  <tr>
    <td class="tg-yw4l">Harith Neralla</td>
    <td class="tg-yw4l">Web Service (WCF)</td>
    <td class="tg-yw4l">getLocationDetails(…)<br>Input: string (zipcode)<br>Output: array of string</td>
    <td class="tg-yw4l">Uses existing API to<br>find the weather and<br>location details for the<br>entered ZIP code.</td>
  </tr>
  <tr>
    <td class="tg-yw4l">Harith Neralla</td>
    <td class="tg-yw4l">Web Service (WCF)</td>
    <td class="tg-yw4l">findStore(…)<br>Input: zipcode and<br>storeName<br>Output: string</td>
    <td class="tg-yw4l">Finds location of the<br>storeName in the ZIP<br>code. Provides store<br>rating and address.</td>
  </tr>
  <tr>
    <td class="tg-yw4l">Harith Neralla</td>
    <td class="tg-yw4l">Web Service (WCF)</td>
    <td class="tg-yw4l">findDistance(…)<br>Input: current and<br>destination address/ZIP
        <br />
        code<br>Output: array of string</td>
    <td class="tg-yw4l">Uses existing API to find<br>the distance between<br>two locations. Will<br>provide best route and<br>link to external map<br>service.</td>
  </tr>
  <tr>
    <td class="tg-yw4l">ASU Repository</td>
    <td class="tg-yw4l">RESTful Web Service</td>
    <td class="tg-yw4l">GetRandomString()<br>Input: none<br>Output: string</td>
    <td class="tg-yw4l">Returns a random string.</td>
  </tr>
  <tr>
    <td class="tg-yw4l">ASU Repository</td>
    <td class="tg-yw4l">Web Service (WCF)</td>
    <td class="tg-yw4l">GetVerifierString(...) & GetImage(...)<br>Input: string & string<br>Output: string & stream</td>
    <td class="tg-yw4l">Returns image verifying components.</td>
  </tr>
  <tr>
    <td class="tg-yw4l">Harith Neralla</td>
    <td class="tg-yw4l">DLL Function</td>
    <td class="tg-yw4l">Encrypt(...)<br>Input: string<br>Output: string</td>
    <td class="tg-yw4l">Returns an encrypted string.</td>
  </tr>
  <tr>
    <td class="tg-yw4l">Harith Neralla</td>
    <td class="tg-yw4l">DLL Function</td>
    <td class="tg-yw4l">Decrypt(...)<br>Input: string<br>Output: string</td>
    <td class="tg-yw4l">Returns a decrypted string.</td>
  </tr>
</table>

</asp:Content>