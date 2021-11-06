<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContaCaracter.ascx.cs" Inherits="NorthwindWebForm.UserControl.ContaCaracter" %>
<script type="text/javascript">    
        //conta numero de caracteres
        function counterCharacter(textBoxID,labelID,maxLength) {
            
            var textbox = document.getElementById(textBoxID);
            var value = textbox.value;            
            var l = value.length;
            var t = maxLength;
            var formatString = '{0} / {1} caracteres';
            for (var i = 0; i < value.length; i++) {
                if (value[i] == '\n')
                    l++;
        }
        var label = document.getElementById(labelID);
        label.innerHTML = formatString.replace('{0}', l).replace('{1}', t);
    }    
</script>
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
