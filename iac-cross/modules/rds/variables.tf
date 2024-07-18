variable "prefix" {}
variable "cluster_name" {}
variable "vpc_id" {}
variable "subnet_ids" {}
variable "eks_sg_id" {}
variable "rds_sg_id" {}
variable "db_name" {}
variable "db_username" {}
variable "db_password" {}
variable "instance_class" {
  default = "db.t3.micro"
}
variable "allocated_storage" {
  default = 20
}
variable "engine_version" {
  default = "16.3"
}
variable "home_ip" {
  description = "Home IP address to allow access"
  type        = string
}
