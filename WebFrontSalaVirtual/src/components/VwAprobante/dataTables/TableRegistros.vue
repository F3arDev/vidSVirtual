<template>
	<h3>Tabla Registros</h3>
	<div class="container">
		<div class="col-md-12">
			<div class="panel panel-default">
				<div class="panel-heading">
					Employee
				</div>
				<div class="panel-body">
					<table class="table table-condensed table-striped">
						<thead>
							<tr>
								<th>#</th>
								<th>Fist Name</th>
								<th>Last Name</th>
								<th>City</th>
								<th>State</th>
								<th>Status</th>
							</tr>
						</thead>

						<tbody>
							<tr data-toggle="collapse" data-target="#demo2" class="accordion-toggle">
								<td>
									<button class="btn btn-default btn-xs">#</button>
								</td>
								<td>Silvio</td>
								<td>Santos</td>
								<td>São Paulo</td>
								<td>SP</td>
								<td> new</td>
							</tr>
							<tr>
								<td colspan="6" class="hiddenRow">
									<div id="demo2" class="accordian-body collapse">Demo2</div>
								</td>
							</tr>

						</tbody>
					</table>
				</div>

			</div>

		</div>
	</div>
</template>

<script setup>

</script>

<style scoped>
body {
	padding-top: 50px;
	background-color: #34495e;
}

.hiddenRow {
	padding: 0 !important;
}
</style>