app.service('PeopleServices',function ($http) {




	this.GetPerson = function () {
		return $http({
			method: "get",
			url: "/Person/person"
		});
	}


	this.GetOrders = function () {
		return $http({
			method: "get",
			url: "/Order/Orders"
		});
	}

	this.GetCustomer = function () {
		return $http({
			method: "get",
			url: "/Order/People"
		});
	}

	this.GetProducts = function () {
	    return $http({
	        method: "get",
	        url: "/Order/Products"
	    });
	}

	this.HexPrice = function (Price) {

	   alert("Price Hexadecimal value =="+ Price.toString(16));
	}

	
});