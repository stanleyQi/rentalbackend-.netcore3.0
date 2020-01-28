. 搭建asp.net core3.0,sqlserver,ef core; 3层架构webapi开发环境
. 配置autofac IOC容器
. 配置identity(in-biuld DI management)
. jwtbearer cookie base token

------------------------------------------------------------------------------------
. 实现登录，注册功能(目前api项目的add-migration有问题，需要使用其他手段在rental数据库建立用户相关表)
. 实现基于角色的鉴权
	
	例：
			request:	https://localhost:5001/user/login	(post)
				Headers:	content-type:application/json
				Body:		{"Email":"4@4","Password":"Oraclepro4!"}
				response:	
							{
								"code": "00008",
								"message": "Operation errors",
								"error": "An operation error happened."
							}

			request:	https://localhost:5001/user/register	(post)
				Headers:	content-type:application/json
				Body:		{"Email":"4@4","Password":"Oraclepro4!","Role":"tenant"}
				response:	
							token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0QDQiLCJqdGkiOiI1YWM2OTQ4Yi05ODRhLTQzYjItOTNjNC0zN2FkNzM2NmY0NTciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImI4NTg3ZjIwLWVjMDQtNDcyOS05N2VmLTgyNmIzZjI2ODliMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InRlbmFudCIsImV4cCI6MTU4MDgwODcyOCwiaXNzIjoicmVudGFsLWJhY2tlbmQtbGlxaS1pc3N1ZXIiLCJhdWQiOiJyZW50YWwtYmFja2VuZC1saXFpLWlzc3VlciJ9.Dv3poCe85bn3pE6LNkS4dDJS-T4DFCeqPOWsn-3-jTQ"
			
			request:	https://localhost:5001/api/application/	(AllowAnonymous;get)
				Headers:	content-type:application/json
				Body:		none
				response:
							[
								{
									"title": "app1"
								},
								{
									"title": "app2"
								},
								{
									"title": "app3"
								}
							]

			request:	https://localhost:5001/api/application/1	(role=tenant;get)
				Headers:	content-type:application/json
				Authorization:	Bearer Token "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0QDQiLCJqdGkiOiI1YWM2OTQ4Yi05ODRhLTQzYjItOTNjNC0zN2FkNzM2NmY0NTciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImI4NTg3ZjIwLWVjMDQtNDcyOS05N2VmLTgyNmIzZjI2ODliMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InRlbmFudCIsImV4cCI6MTU4MDgwODcyOCwiaXNzIjoicmVudGFsLWJhY2tlbmQtbGlxaS1pc3N1ZXIiLCJhdWQiOiJyZW50YWwtYmFja2VuZC1saXFpLWlzc3VlciJ9.Dv3poCe85bn3pE6LNkS4dDJS-T4DFCeqPOWsn-3-jTQ"
				Body:		none
				response:	"Secrit info: Only tenant can access."

------------------------------------------------------------------------------------