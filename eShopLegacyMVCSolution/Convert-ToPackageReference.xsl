<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns="http://schemas.microsoft.com/developer/msbuild/2003">

  <xsl:output omit-xml-declaration="yes" method="xml" indent="no"/>

  <xsl:template match="/">
    <xsl:element name="Project">
        <xsl:element name="ItemGroup">
            <xsl:apply-templates/>
        </xsl:element>
    </xsl:element>
  </xsl:template>

  <xsl:template match="package">
    <xsl:element name="PackageReference">
        <xsl:attribute name="Include">
            <xsl:value-of select="@id" />
        </xsl:attribute>
        <xsl:element name="Version">
            <xsl:value-of select="@version" />        
      </xsl:element>
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>