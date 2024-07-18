variable "prefix" {}
variable "vpc_cidr_block" {
  default = "10.0.0.0/16"
}
variable "cluster_name" {}
variable "retention_days" {
  default = 5
}
variable "desired_size" {
  default = 2
}
variable "max_size" {
  default = 3
}
variable "min_size" {
  default = 1
}
variable "db_name" {}
variable "db_username" {
}
variable "db_password" {}
variable "instance_class" {
  default = "db.t3.micro"
}
variable "allocated_storage" {
  default = 20
}
variable "home_ip" {
  description = "Home IP address to allow access"
  type        = string
}