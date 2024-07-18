data "aws_security_group" "eks_cluster_sg_auto_generated" {
  filter {
    name   = "group-name"
    values = ["${var.cluster_name}-cluster-sg-${var.prefix}-*"]
  }
}



resource "aws_security_group" "rds_sg" {
  vpc_id = var.vpc_id

  ingress {
    from_port   = 5432
    to_port     = 5432
    protocol    = "tcp"
    cidr_blocks =  ["${var.home_ip}/32"]
    description = "Allow access from home IP"
  }

  ingress {
    from_port   = 5432
    to_port     = 5432
    protocol    = "tcp"
    security_groups = [data.aws_security_group.eks_cluster_sg_auto_generated.id]
    description = "Allow access from EKS security group"
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  tags = {
    Name = "${var.prefix}-rds-sg"
    IAC  = "True"
  }
}

resource "aws_db_instance" "rds" {
  allocated_storage    = var.allocated_storage
  storage_type         = "gp2"
  engine               = "postgres"
  engine_version       = var.engine_version
  instance_class       = var.instance_class
  identifier           = var.db_name
  username             = var.db_username
  password             = var.db_password
  db_subnet_group_name = aws_db_subnet_group.rds_subnet_group.name
  vpc_security_group_ids = [aws_security_group.rds_sg.id]
  skip_final_snapshot  = true
  publicly_accessible  = true

  tags = {
    Name = "${var.prefix}-rds"
    IAC  = "True"
  }
}

resource "aws_db_subnet_group" "rds_subnet_group" {
  name       = "${var.prefix}-rds-subnet-group"
  subnet_ids = var.subnet_ids

  tags = {
    Name = "${var.prefix}-rds-subnet-group"
    IAC  = "True"
  }
}