$(() => {
	const msg = $("#hiddenPopupMessage").val();

	if (msg != null && msg.length != 0) {
		alert(msg);
	}
	
});