output "eks_id" {
  value = aws_eks_cluster.cluster.id
}

output "eks_sg_id" {
  value = aws_security_group.sg.id
}
