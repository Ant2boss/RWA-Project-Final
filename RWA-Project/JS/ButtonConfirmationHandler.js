$(() => {
	$("body").on("click", ".btnDeleteConfirm", function (e) {
		if (!confirm("Jeste sigurni?")) {
			e.preventDefault();
		}
	});

	$("body").on("click", ".btnConfirmDialog", function (e) {
		if (!confirm("Jeste sigurni?")) {
			e.preventDefault();
		}
	});

});