<%@Page Language="C#" %>
<% @Import Namespace="System.Globalization" %>
<html>
    <head>
    </head>
    <script runat=server>
        public void Page_Load()
        {
            Response.Write ("Current Culture is " + CultureInfo.CurrentCulture.EnglishName);
        }
    </script>
    <body>
    </body>
</html>