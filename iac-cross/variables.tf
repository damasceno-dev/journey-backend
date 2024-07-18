variable "prefix" {}
variable "vpc_cidr_block" {}
variable "cluster_name" {}
variable "retention_days" {}
variable "desired_size" {}
variable "max_size" {}
variable "min_size" {}
variable "db_name" {}
variable "db_username" {}
variable "db_password" {}
variable "instance_class" {
  default = "db.t3.micro"
}
variable "allocated_storage" {
  default = 20
}