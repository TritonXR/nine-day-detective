for file in $(git status | grep "both modified:" | awk '{print $3}'); do
    git checkout --theirs $file;
done
