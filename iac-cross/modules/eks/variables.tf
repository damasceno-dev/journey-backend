variable "vpc_id" {}
variable "prefix" {}
variable "cluster_name" {}
variable "retention_days" {
  default = 5
}
variable "subnet_ids" {}
variable "desired_size" {
  default = 2
}
variable "max_size" {
  default = 3
}
variable "min_size" {
  default = 1
}