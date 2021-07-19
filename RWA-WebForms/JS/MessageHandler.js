$(() => {
	var labelContents = $("#lbAlertMessage").html();

	if (labelContents != null && labelContents != "") {
		alert(labelContents);
	}
});