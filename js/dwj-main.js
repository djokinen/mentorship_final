$(function () {
	$("input:radio[name=roletype]").click(function () {
		$("#hiddenRoleType").val($(this).val());
	});
});