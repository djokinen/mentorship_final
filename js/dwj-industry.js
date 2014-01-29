$(function () {
	$("#buttonRight").on("click", function (e) {
		addToGroup();
	});

	$("#buttonLeft").on("click", function (e) {
		removeFromGroup();
	});

	$("#buttonSave").on("click", function (e) {
		saveGroup();
	});

});

function addToGroup() {
	var li;
	li = $(".all_industries input:checked").removeAttr("checked").parent("li");
	li.each(function (i, elem) {
		var me, label, id;
		me = $(this);
		label = me.find("label").text();
		id = me.find("input:checkbox").val();
		$("<option/>").val(id).text(label).appendTo("#groupLeader");
		me.clone().appendTo(".group_industries");
		me.remove();
	});
	refreshControls();
}

function removeFromGroup() {
	var li;
	li = $(".group_industries input:checked").removeAttr("checked").parent("li");
	li.each(function (i, elem) {
		var me, id;
		me = $(this);
		id = me.find("input:checkbox").val();
		$("#groupLeader option[value=" + id + "]").remove();
		$("#groupLeader").select([]);
		me.clone().appendTo(".all_industries");
		me.remove();
	});
	refreshControls();
}

function saveGroup(e) {
	if (Page_ClientValidate("group")) {
		_isDirty = false;
		var name = $("#textName").val();
		var description = $("#textDescription").val();
		var groupLeaderId = $("select#groupLeader").val();
		var groupMembers = $("#groupMembers").val();
		var communityId = GetQueryStringValue("cid");
		var communityGroupId = GetQueryStringValue("cgid");
		CommunityGroupWS.Set(name, description, groupLeaderId, groupMembers, communityId, communityGroupId, setCallback);
	}
}

function setCallback(result) {
	window.location.href = result;
}

function refreshGroupMembers() {
	var arr;
	arr = [];
	$(".group_industries li").each(function (i, elem) {
		arr.push($(this).find("input:checkbox").val());
	});
	$("#groupMembers").val(arr.join());
}

function refreshControls() {
	if (!$(".group_industries li").length) {
		$("#buttonLeft").attr("disabled", "disabled");
		$("#groupLeader").attr("disabled", "disabled");
	} else {
		$("#buttonLeft").removeAttr("disabled");
		$("#groupLeader").removeAttr("disabled");
	}
	if (!$(".all_industries li").length) {
		$("#buttonRight").attr("disabled", "disabled");
	} else {
		$("#buttonRight").removeAttr("disabled");
	}
	refreshGroupMembers();
}