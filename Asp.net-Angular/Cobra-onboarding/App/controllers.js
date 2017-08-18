app.controller("myCtrl", function ($scope,$http, PeopleServices) {
	debugger;
	$scope.cId = "";
	$scope.pId = "";

	//Update Person
	$scope.personUpdate = function (isValid) {

		if (isValid) {

			$scope.people = {};
			$scope.people.Id = document.getElementById("personId").value;
			$scope.people.Name = $scope.Name;
			$scope.people.Address1 = $scope.Addr;
			$scope.people.Address2 = $scope.Add2;
			$scope.people.City = $scope.City;

			$http({
				method: "post",
				url: "/Person/UpdatePerson",
				datatype: "json",
				data: JSON.stringify($scope.people)
			}).then(function (response) {
				alert(response.data);
				$("#myModalHorizontal2").modal('toggle');
				$scope.getPerson();
				$scope.Id = "";
				$scope.Name = "";
				$scope.Addr = "";
				$scope.Add2 = "";
				$scope.City = "";
			})
		} else {

			alert("No Blanks Required!");
		}
	}


	//Add new Person
	$scope.addPerson = function (isvalid) {

		if (isvalid) {
			$scope.newPeople = {};
			//$scope.people.Id = $scope.Id1;
			$scope.newPeople.Name = $scope.Name1;
			$scope.newPeople.Address1 = $scope.Addr1;
			$scope.newPeople.Address2 = $scope.Add21;
			$scope.newPeople.City = $scope.City1;
			$http({
				method: "post",
				url: "/Person/InsertPeople",
				datatype: "json",
				data: JSON.stringify($scope.newPeople)
			}).then(function (response) {
				alert(response.data);
				$("#myModalHorizontal").modal('toggle');
				$scope.getPerson();
				//$scope.Id1 = "";
				$scope.Name1 = "";
				$scope.Addr1 = "";
				$scope.Add21 = "";
				$scope.City1 = "";

			})
		}else{alert("Please Fill all the Fields!")}
	}


	//Set update data to People Update Modal
	$scope.getUpdatePersonData = function (person) {
		document.getElementById("personId").value = person.Id;
		$scope.Id = person.Id;
		$scope.Name = person.Name;
		$scope.Addr = person.Address1;
		$scope.Add2 = person.Address2;
		$scope.City = person.City;

	   
	}

	//Get all People
	$scope.getPerson = function () {
		PeopleServices.GetPerson().then(function (response) {
			$scope.people = response.data;

		}, function () {
			alert("Error Occur");
		})
	};
	

	//Delete Person
	$scope.deletePerson = function (person) {
	    debugger;
		$http({
			method: "post",
			url: "/Person/DeletePerson",
			datatype: "json",
			data: JSON.stringify(person)
		}).then(function (response) {
			alert(response.data);
			$scope.getPerson();
		})
	};

	//Get Orders
	$scope.getOrder = function () {
		PeopleServices.GetOrders().then(function (response) {
			debugger;
			$("#UpdateForm").hide();
			$("#AddForm").show();
			$scope.order = response.data;

		});

	};

	//Get all People
	PeopleServices.GetCustomer().then(function (response) {
		$scope.cId = response.data;
	});

	//Get all Products
	PeopleServices.GetProducts().then(function (response) {
		$scope.pId = response.data;
	});

	
	//Add new Order
	$scope.addNewOrder = function (isValid) {
		debugger;

		if (isValid) {
			var Order = {

				Id: $scope.Id,
				OrderDate: $scope.OrderDate,
				PersonId: document.getElementById("customerId").value,
				ProductId: document.getElementById("productId").value,
				Price: $scope.Price
			};
			$http({
				method: "post",
				url: "/Order/AddOrderDetails",
				data: JSON.stringify(Order),
				dataType: "json"
			}).then(function (response) {

				alert(response.data);
				$("#myModalHorizontal").modal('toggle');
				$scope.getOrder();
				$scope.OrderDate = "";
				$scope.cusId = "";
				$scope.Product = "";
				$scope.Price = "";


			});

		} else { alert("Please fill all the fields!");}
		
		

	}

	
	//Set data to update modal
	$scope.updateOrder = function (orders) {
		$scope.Id = orders.Id;
		$scope.OrderDate2 = orders.OrderDate;
		$scope.upCusName = orders.Name;
		$scope.upProduct = orders.ProductName;
		$scope.price = orders.Price;
		$scope.pp=PeopleServices.HexPrice(orders.Price);

	
	}

	//Update order
	$scope.updateOrderEvt = function (isValid) {

	   if (isValid) {

		var uporder = {

			Id: document.getElementById("productDetailsId").value,
			OrderId: $scope.Id,
			OrderDate: $scope.OrderDate2,
			PersonId: $scope.data,
			ProductId: $scope.upProduct.Id,
		 
			
		};

		
			$http({
				method: "post",
				url: "/Order/upOrder",
				datatype: "json",
				data: JSON.stringify(uporder)
			}).then(function (response) {
				$("#myModalHorizontal2").modal('toggle');
				alert(response.data);
				$scope.Id = "";
				$scope.OrderDate = "";
				$scope.data = "";
				$scope.upProduct = "";
				$scope.getOrder();

			});
		} else { alert("Please Check all the Fields!");}

	}

	//Delete Order
	$scope.deleteOrder = function (orders) {
	 
		$http({
			method: "post",
			url: "/Order/DeleteOrder",
			datatype: "json",
			data: JSON.stringify(orders)
		}).then(function (response) {
			alert(response.data);
			$scope.getOrder();
		})
	};
})




