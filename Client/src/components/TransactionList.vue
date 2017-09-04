<style>
    .transaction-list {
        background-color: #fbfbfb;
        height: 100vh;
        width: 280px;
        border-right: solid 1px #d4d4d4;
        padding-left: 95px;
        padding-top: 13px;
    }

    .h3{
    	font-family: lato;
    	font-size: 18px;
    	font-weight:600;
    	color: #153b50;
    }

    .filters{
    	padding-top: 30px;
    }

    .h6{
    	font-family: lato;
    	font-size: 10px;
    	font-weight:700;
    	color: #a1b1b9;
    	padding-bottom: 15px;
    	letter-spacing: .2px;
    }

     .actions{
    	font-family: lato;
    	font-size: 10px;
    	font-weight:700;
    	color: #a1b1b9;
    	padding-top: 50px;
    	padding-bottom: 15px;
    	letter-spacing: .2px;
    }

    .btn{
    	height: 35px;
    	width: 170px;
    	background-color: #fff;
    	border: solid 1px #d4d4d4;
    	border-radius: 2px;
    	background: #fff;
    	font-family: lato;
    	padding-right: 80px;
    }

    .dropdown{
    	justify-content: left;
    	padding-bottom: 8px;
    }

    .btn-primary{
    	width: 170px;
    	height: 40px;
    	border-radius: 4px;
    	border-color: transparent;
    	background-color: #1976d2;
    	color: #fff;
    	font-family: lato;
    	font-weight: 400;
    	font-size: 13px;
    	box-shadow: none;
    	letter-spacing: .3px;
    	margin-bottom: 20px;
    }

    .btn-primary:hover{
    	width: 170px;
    	height: 40px;
    	border-radius: 4px;
    	border-color: transparent;
    	background-color: #105fae;
    	color: #fff;
    	font-family: lato;
    	font-weight: 400;
    	letter-spacing: .3px;
    	font-size: 13px;
    	box-shadow: none;
    	margin-bottom: 20px;
    }

    .btn-text{
    	color: #1976d2;
    	background:transparent;
    	box-shadow: none;
    	border: none;
    	padding-top: 2px;
    	font-family: lato;
    	font-weight: 500;
    	font-size: 13px;
    	margin-top: 4px;
    }

    .icon-pencil{
    	width: 13px;
    	margin-right: 8px;
    	margin-top: -4px;
    }

 .icon-trash{
    	width: 10px;
    	margin-right: 8px;
    	margin-top: -4px;
    }




</style>

<template>

    <div class="col-xs-4 transaction-list">
        <h3 class="h3"> Transaction List </h3>
         <div class="filters">
    		<h6 class="h6">FILTERS</h6>

    		<div class="dropdown">
    			<button class="btn" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Past 7 days</button>
			  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
			    <a class="dropdown-item" href="#">Action</a>
			    <a class="dropdown-item" href="#">Another action</a>
			    <a class="dropdown-item" href="#">Something else here</a>
			  </div>
			</div>

			<div class="dropdown">
			  <button class="btn" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">All categories</button>
			  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
			    <a class="dropdown-item" href="#">Action</a>
			    <a class="dropdown-item" href="#">Another action</a>
			    <a class="dropdown-item" href="#">Something else here</a>
			  </div>
			</div>

			<h6 class="actions">ACTIONS</h6>
			<button class="btn-primary">Add transaction</button>
			<ul>
              <button class="btn-text"><img src="../../images/pencil.png" class='icon-pencil'>Edit transaction</button>
			</ul>
			<ul>
               <button class="btn-text"><img src="../../images/delete.png" class='icon-trash'>Delete transaction</button>
			</ul>





    	</div>
    </div>


</template>
