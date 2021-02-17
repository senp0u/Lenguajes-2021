package cr.ac.ucr.teleatlantico.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import cr.ac.ucr.teleatlantico.domain.Issue;

@Repository
public interface IssueRepository extends JpaRepository<Issue, Integer>{

}
