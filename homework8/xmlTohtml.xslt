<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Order List</h1>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>orderNumber</th>
            <th>NumberOfOrder</th>
            <th>orderTotalPrice</th>
            <th>phoneNumber</th>
            <th>numOfDetails</th>
            <th>kindOfGoods</th>
            <th>numberOfGoods</th>
            <th>price</th>
            <th>totalPrice</th>
          </tr>
          <xsl:for-each select="ArrayOfOrder/Order/orderDetails/OrderDetails">
            <tr>
              <td>
                <xsl:value-of select="../../customerName " />
              </td>
              <td>
                <xsl:value-of select="../../orderNumber" />
              </td>
              <td>
                <xsl:value-of select="../../orderTotalPrice" />
              </td>
              <td>
                <xsl:value-of select="../../phoneNumber" />
              </td>
              <td>
                <xsl:value-of select="../../numOfDetails" />
              </td>
              <td>
                <xsl:value-of select="kindOfGoods" />
              </td>
              <td>
                <xsl:value-of select="numberOfGoods" />
              </td>
              <td>
                <xsl:value-of select="price" />
              </td>
              <td>
                <xsl:value-of select="totalPrice" />
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

