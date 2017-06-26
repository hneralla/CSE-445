<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>
		<head>
		<style>
			h1 {
				font-family: "Lucida Grande", "Lucida Sans Unicode", "Lucida Sans", Geneva, Verdana, sans-serif;
				font-size: 30px;
				font-style: normal;
				font-variant: normal;
				font-weight: 500;
				line-height: 26.4px;		
			}

			b {
			font-family: "Lucida Grande", "Lucida Sans Unicode", "Lucida Sans", Geneva, Verdana, sans-serif;
			font-size: 14px;
			line-height: 20px;
			}
		</style>
		</head>  
			<body>
			<h1>Persons</h1>
			<table border="1">
				<tr> 
					<td><b>First Name</b></td> 
					<td><b>Last Name</b></td> 
					<td><b>Work Phone</b></td> 
					<td><b>Cell Phone</b></td> 
					<td><b>Provider</b></td> 
					<td><b>Category</b></td>
				</tr>
				<xsl:for-each select="Persons/Person">
					<xsl:sort select="Name/Last" />
					<tr style="font-size: 10pt; font-family: verdana">
						<td><xsl:value-of select="Name/First"/></td>
						<td><xsl:value-of select="Name/Last"/></td>
						<td><xsl:value-of select="Phone/Work"/></td>
						<td><xsl:value-of select="Phone/Cell"/></td>
						<td><xsl:value-of select="Phone/Cell/@Provider"/></td>
						<td><xsl:value-of select="Category"/></td>
					</tr>
				</xsl:for-each>
			</table>
		</body> </html>
	</xsl:template>
</xsl:stylesheet>