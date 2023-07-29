insert into SYS_USER_ROLE 
(user_id, role_id, state_id)
(select (select id from sys_user where user_name = 'admin' limit 1), (select id from sys_role where is_admin limit 1), 1);
