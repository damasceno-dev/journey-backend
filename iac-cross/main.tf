terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "5.40.0"
    }
  }
}

provider "aws" {
  region = "us-east-1"
}

module "vpc" {
  source         = "./modules/vpc"
  prefix         = var.prefix
  vpc_cidr_block = var.vpc_cidr_block
}

module "eks" {
  source         = "./modules/eks"
  prefix         = var.prefix
  vpc_id         = module.vpc.vpc_id
  subnet_ids     = module.vpc.subnet_ids
  cluster_name   = var.cluster_name
  retention_days = var.retention_days
  desired_size   = var.desired_size
  max_size       = var.max_size
  min_size       = var.min_size
}

module "rds" {
  source       = "./modules/rds"
  prefix       = var.prefix
  vpc_id       = module.vpc.vpc_id
  subnet_ids   = module.vpc.subnet_ids
  eks_sg_id    = module.eks.sg_id
  db_name      = var.db_name
  db_username  = var.db_username
  db_password  = var.db_password
  instance_class = var.instance_class
  allocated_storage = var.allocated_storage
}