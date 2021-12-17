
function GetAllPerson() {
	$.get("/People/GetListPerson", null, function (data) {
		$("#ListOfPerson").html(data);
	});
	document.getElementById('messages').innerText = "All Avilable Person";
}

function FindPersonById() {
	var idOfPersonValue = document.getElementById('personIdValue').value;
	$.post("/People/FindById", { personId: idOfPersonValue },
		function (data) {
			$("#ListOfPerson").html(data);
	});

	document.getElementById('messages').innerText = "Search Result";
}



function RemovePersonById() {
	var idOfPersonValue = document.getElementById('personIdValue').value;
	$.post("/People/DeletePerson", { personId: idOfPersonValue }, function (data) {
		
	})
		.done(function () {
			GetPersonList();
			document.getElementById('messages').innerHTML = "Successfully Deleted Person";
			
		})
		.fail(function () {
			document.getElementById('messages').innerHTML = "Sorry ;( Could not delete Person";
		});
}


